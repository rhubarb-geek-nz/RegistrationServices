# rhubarb-geek-nz/RegistrationServices

Demonstration of local server COM object in C#.

IDL is compiled into a type library.

```
midl disptlb.idl /client none /server none /tlb RhubarbGeekNz.RegistrationServices.tlb /out .
```

Type library is used to create a .NET assembly.

```
tlbimp RhubarbGeekNz.RegistrationServices.tlb /asmversion:1.0.0.0 /namespace:RhubarbGeekNz.RegistrationServices /machine:Agnostic /out:RhubarbGeekNz.RegistrationServices.dll
```

Assembly is packaged into a nuget package.

```
mkdir base\lib\netstandard2.0
copy RhubarbGeekNz.RegistrationServices.dll base\lib\netstandard2.0
nuget pack disptlb.nuspec -BasePath base
```

Package is referenced by server project.

```
<PackageReference Include="rhubarb-geek-nz.RegistrationServices" Version="1.0.0" />
```

Implementation class derives from interface from assembly.

```
[Guid("d8dfbd42-569c-47c1-9523-9369e67371d1")]
public class CHelloWorld : IHelloWorld
```

Server publishes implementation class using RegistrationServices.

```
var registrationServices = new System.Runtime.InteropServices.RegistrationServices();
registrationServices.RegisterTypeForComClients(typeof(CHelloWorld), RegistrationClassContext.LocalServer, RegistrationConnectionType.MultipleUse);
```

Test with PowerShell using Activator.

```
$guid = [Guid]::Parse('d8dfbd42-569c-47c1-9523-9369e67371d1')
$type = [Type]::GetTypeFromCLSID($guid)
$obj = [Activator]::CreateInstance($type)
$obj.GetMessage(1)
```

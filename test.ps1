# Copyright (c) 2025 Roger Brown.
# Licensed under the MIT License.

param($CLSID = 'd8dfbd42-569c-47c1-9523-9369e67371d1', $Method = 'GetMessage', $Hint = 1)

$guid = [Guid]::Parse($CLSID)
$type = [Type]::GetTypeFromCLSID($guid)
$obj = [Activator]::CreateInstance($type)
$obj.$Method($Hint)

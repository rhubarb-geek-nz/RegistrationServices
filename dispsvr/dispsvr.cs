/***********************************
 * Copyright (c) 2025 Roger Brown.
 * Licensed under the MIT License.
 ****/

using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace RhubarbGeekNz.RegistrationServices
{
    [Guid("d8dfbd42-569c-47c1-9523-9369e67371d1")]
    public class CHelloWorld : IHelloWorld
    {
        public string GetMessage(int Hint)
        {
            if (Hint == -1)
            {
                Program.CancellationTokenSource.Cancel();

                return "Goodbye, Cruel World";
            }

            return "Hello World";
        }
    }

    internal class Program
    {
        internal static CancellationTokenSource CancellationTokenSource = new CancellationTokenSource();

        static void Main(string[] args)
        {
            Console.CancelKeyPress += delegate (object sender, ConsoleCancelEventArgs e)
            {
                e.Cancel = true;
                CancellationTokenSource.Cancel();
            };

            var registrationServices = new System.Runtime.InteropServices.RegistrationServices();

            int cookie = registrationServices.RegisterTypeForComClients(typeof(CHelloWorld), RegistrationClassContext.LocalServer, RegistrationConnectionType.MultipleUse);

            try
            {
                CancellationTokenSource.Token.WaitHandle.WaitOne();
            }
            finally
            {
                registrationServices.UnregisterTypeForComClients(cookie);
            }
        }
    }
}

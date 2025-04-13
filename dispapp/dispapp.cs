/***********************************
 * Copyright (c) 2025 Roger Brown.
 * Licensed under the MIT License.
 ****/

using System;

namespace RhubarbGeekNz.RegistrationServices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IHelloWorld helloWorld = new CHelloWorld();

            foreach (var arg in args)
            {
                Console.WriteLine($"{helloWorld.GetMessage(Int32.Parse(arg))}");
            }
        }
    }
}

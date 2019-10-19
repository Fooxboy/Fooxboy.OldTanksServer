using System;

namespace Fooxboy.OldTanksServer.Shell.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World!");
            var server = new Server(null, "localhost", 2535);
            server.Start();
            System.Console.WriteLine("Ready.");
            System.Console.ReadLine();
        }
    }
}

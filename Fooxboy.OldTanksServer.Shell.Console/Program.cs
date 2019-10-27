using Fooxboy.OldTanksServer.Interfaces;
using System;

namespace Fooxboy.OldTanksServer.Shell.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Old Tanks Shell by Fooxboy");
            ILoggerServer logger = new LoggerServer();
            var server = new Server(logger, "localhost", 2535);
            var cm = new CommandManager(server.Api, logger);
            cm.Init();
            server.Start();
            System.Console.WriteLine("Ready.");
            while(true)
            {
                logger.Shell("Чтобы узнать доступные консольные команды, напишите help.");
                var text = System.Console.ReadLine();
                cm.StartExecute(text);
            }
            
        }
    }
}

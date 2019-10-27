using Fooxboy.OldTanksServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Fooxboy.OldTanksServer.Shell.Console.ConsoleCommands
{
    public class HelpCommand : IConsoleCommand
    {
        private readonly ILoggerServer _logger;
        private readonly Api _api;
        public HelpCommand(Api api, ILoggerServer logger)
        {
            _api = api;
            _logger = logger;
        }
        public string Trigger => "help";

        public void Execute()
        {
            _logger.Server("Список всех доступных консольных команд:\n" +
                "");
            
           //TODO: получение списка всех доступных команд из консоли.
        }
    }
}

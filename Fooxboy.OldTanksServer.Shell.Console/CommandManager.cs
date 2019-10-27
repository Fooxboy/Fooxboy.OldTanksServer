using Fooxboy.OldTanksServer.Interfaces;
using Fooxboy.OldTanksServer.Shell.Console.ConsoleCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fooxboy.OldTanksServer.Shell.Console
{
    public class CommandManager
    {
        private readonly List<IConsoleCommand> _commands;
        private readonly Api _api;
        private readonly ILoggerServer _logger;
        public CommandManager(Api api, ILoggerServer logger)
        {
            _commands = new List<IConsoleCommand>();
            _api = api;
            _logger = logger;
        }
        public void Init()
        {
            _commands.Add(new HelpCommand(_api, _logger));
            _commands.Add(new SayCommand(_api));
        }

        public void StartExecute(string text)
        {
            var words = text.Split(" ");
            var command = _commands.Single(u => u.Trigger == words[0]);
            if (command != null) command.Execute(words);
        }
    }
}

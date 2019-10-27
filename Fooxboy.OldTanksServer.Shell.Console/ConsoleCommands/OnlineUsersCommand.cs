using Fooxboy.OldTanksServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Shell.Console.ConsoleCommands
{
    public class OnlineUsersCommand : IConsoleCommand
    {
        private readonly Api _api;
        private readonly ILoggerServer _logger;
        public OnlineUsersCommand(Api api, ILoggerServer logger)
        {
            _api = api;
            _logger = logger;
        }
        public string Trigger => "online";

        public void Execute(string[] words)
        {
            var users = _api.Server.GetOnlineUsers();
            var stringUsers = "Пользователи онлайн: \n";
            foreach(var user in users) stringUsers += $"- {user.Nickname} \n";
            _logger.Shell(stringUsers);
        }
    }
}

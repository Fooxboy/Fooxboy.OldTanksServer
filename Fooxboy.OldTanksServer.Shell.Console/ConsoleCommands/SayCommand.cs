using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Shell.Console.ConsoleCommands
{
    public class SayCommand : IConsoleCommand
    {
        private readonly Api _api;
        public SayCommand(Api api)
        {
            _api = api;
        }
        public string Trigger => "say";

        public void Execute(string[] words)
        {
            var message = string.Empty;
            for(int i=1; i< words.Length; i++) message += $"{words[i]} ";
            _api.Chat.SendServerMessage(message);
        }
    }
}

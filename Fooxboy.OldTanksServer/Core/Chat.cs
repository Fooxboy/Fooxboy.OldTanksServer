using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Core
{
    public class Chat : IRequest
    {
        private readonly Api _api;
        public string Trigger => "chat";
        public Chat(Api api)
        {
            _api = api;
        }
        public string Execute(List<string> message, Lobby lobby)
        {
            var text = message[1];
            if (text[0] == '/'|| text[0] == '\\')
            {
                //todo: обработка комманд.
            }
            var msg = _api.Chat.SendMessage(text, lobby.User);
            return null;
        }
    }
}

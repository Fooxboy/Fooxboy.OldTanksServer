﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Core
{
    public class Chat : IRequest
    {
        public string Trigger => "chat";

        public string Execute(List<string> message, Lobby lobby)
        {
            var text = message[1];
            //todo: обработка сообщения в чате.
        }
    }
}

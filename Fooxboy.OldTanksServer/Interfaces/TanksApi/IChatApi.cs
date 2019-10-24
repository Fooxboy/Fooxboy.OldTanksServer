using Fooxboy.OldTanksServer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Interfaces.TanksApi
{
    public interface IChatApi
    {
        ChatMessage SendMessage(string text, User user);
        Chat GetChat();
        ChatMessage GetMessage(long messageId);
        ChatMessage SendServerMessage(string text);
    }
}

using Fooxboy.OldTanksServer.Interfaces;
using Fooxboy.OldTanksServer.Interfaces.TanksApi;
using Fooxboy.OldTanksServer.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fooxboy.OldTanksServer.TanksApi
{
    public class Chat : IChatApi
    {
        private readonly Models.Chat _chat;
        private readonly ILoggerServer _logger;

        public Chat(ILoggerServer logger)
        {
            _chat = new Models.Chat();
            _chat.Messages = new List<ChatMessage>();
            _logger = logger;
        }

        public Models.Chat GetChat() => _chat;
        public ChatMessage GetMessage(long messageId) => _chat.Messages.Single(m => m.MessageId == messageId);

        public ChatMessage SendMessage(string text, User user)
        {
            var message = new ChatMessage();
            message.MessageId = _chat.Messages.Count;
            message.Rank = 
            //throw new NotImplementedException();
        }

        public ChatMessage SendServerMessage(string text)
        {
            throw new NotImplementedException();
        }
    }
}

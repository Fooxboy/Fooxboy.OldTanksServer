using Fooxboy.OldTanksServer.Helpers;
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
        private readonly Api _api;
        private readonly List<Lobby> _lobbies;

        public Chat(List<Lobby> lobbies, ILoggerServer logger, Api api)
        {
            _chat = new Models.Chat();
            _chat.Messages = new List<ChatMessage>();
            _logger = logger;
            _api = api;
            _lobbies = lobbies;
        }

        public Models.Chat GetChat() => _chat;
        public ChatMessage GetMessage(long messageId) => _chat.Messages.Single(m => m.MessageId == messageId);

        public ChatMessage SendMessage(string text, User user)
        {
            var message = new ChatMessage();
            message.MessageId = _chat.Messages.Count;
            var garage = _api.Garage.GetGarageFromId(user.UserId);
            message.Rank = RankHelper.GetHelper().GetRankFromScore(garage.Score);
            message.Time = DateTime.Now;
            message.User = user;
            _logger.Info($"[CHAT]=> ({message.Rank}) {user.Nickname}:{message.Text}");
            SendToAll(message);
            return message;
        }

        private bool SendToAll(ChatMessage message)
        {
            try
            {
                foreach(var lobby in _lobbies)
                {
                    try
                    {
                        lobby.Send($"cm;{message.User.Nickname};{message.Rank};{message.Text};");
                    }catch(Exception e)
                    {
                        _logger.Error($"[CHAT]=> Произошла ошибка при отправки сообщение в лобби пользователя {lobby.User.Nickname}: \n {e}");
                        lobby.DisconectUser();
                    }
                    
                }
                return true;
            }catch(Exception e)
            {
                _logger.Error($"[CHAT]=> Произошла ошибка при отправке сообщений в чат: \n {e}");
                return false;
            }
        }

        public ChatMessage SendServerMessage(string text)
        {
            var message = new ChatMessage();
            var user = new User();
            user.Nickname = "[SERVER]";
            message.User = user;
            message.Text = text;
            message.Time = DateTime.Now;
            message.Rank = 26;
            message.MessageId = _chat.Messages.Count();
            SendToAll(message);
            _logger.Info("[CHAT]=> Сообщение отправлено.");
            return message;
        }
    }
}

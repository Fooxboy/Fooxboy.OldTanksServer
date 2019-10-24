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
            if (lobby.User.IsBannedChat) return "cm;system;0;Вы заблокированы в чате.;";
            var text = message[1];
            if (text[0] == '/')
            {
                if(lobby.User.TypeUser == 0) return "cm;system;0;Вам недоступны команды.;";
                var words = text.Split(" ");
                var command = words[0];

                if (lobby.User.TypeUser > 0)
                {
                    if (command == "/addcry")
                    {
                        //todo: Добавление кристалов
                    }
                    else if (command == "/addscore")
                    {
                        //todo: Добавление опыта
                    } else if (command == "/gold")
                    {
                        //todo: спавн голда

                    }else if(command == "/crys")
                    {
                        //todo: справн кристалов 
                    }
                }

                if(lobby.User.TypeUser > 1)
                {
                    if(command == "/ban")
                    {
                        //todo: Бан пользователя
                    }else if(command == "/unban")
                    {
                        //todo: Разбан пользователя
                    }else if(command == "/mute")
                    {
                        //todo: Отключение пользователя от чата
                    }
                }
                
                
            }
            var msg = _api.Chat.SendMessage(text, lobby.User);
            return null;
        }
    }
}

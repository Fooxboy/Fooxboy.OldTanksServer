using Fooxboy.OldTanksServer.Helpers;
using Fooxboy.OldTanksServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Fooxboy.OldTanksServer.Core
{
    public class Login:SocketHelper
    {
        private readonly Socket _socket;
        private readonly Server _server;
        public Login(Socket socket, Server server):base(socket)
        {
            _socket = socket;
            _server = server;
        }
        public LoginResult Execute(List<string> message)
        {
            string typeLogin = message[1];
            string nickname = message[2];
            string password = message[3];

            var result = new LoginResult();

            Send("login;");

            if(typeLogin == "1")
            {
                if(CheckOnline(nickname))
                {
                    result.Status = false;
                    result.Error = "Вы уже находитесь в игре. Выйдите с аккаунта.";
                    return result;
                }

                if(!_server.Api.Account.CheckRegister(nickname))
                {
                    result.Status = false;
                    result.Error = "Неверный логин или пароль.";
                    return result;
                }

                var idUser = _server.Api.Account.GetIdFromNickname(nickname);
                var user = _server.Api.Account.GetUserFromId(idUser);
                if(user.Password == password)
                {
                    result.Status = true;
                    result.Id = idUser;
                    result.Nickname = nickname;
                    result.Password = password;
                    result.Token = "token";
                    return result;
                }else
                {
                    result.Status = false;
                    result.Error = "Неверный логин или пароль.";
                    return result;
                }
            }
            //return null;
            //todo: сверяем логин  и пароль и регистрируем, если надо.
            //throw new NotImplementedException();
        }

        private bool CheckOnline(string nickname) => _server.OnlineUsers.Any(u => u.Nickname == nickname);
    }
}

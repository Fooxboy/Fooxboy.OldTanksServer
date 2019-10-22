using Fooxboy.OldTanksServer.Helpers;
using Fooxboy.OldTanksServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
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
                    if(user.IsBanned)
                    {
                        result.Status = false;
                        result.Error = "Ваш аккаунт был заблокирован.";
                        return result;
                    }
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
            }else if(typeLogin == "2")
            {
                try
                {
                    if (_server.Api.Account.CheckRegister(nickname))
                    {
                        result.Status = false;
                        result.Error = "Данный никнейм уже занят.";
                        return result;
                    }

                    var user = _server.Api.Account.Register(nickname, password, "no");
                    if(user != null)
                    {
                        result.Status = true;
                        result.Nickname = nickname;
                        result.Password = password;
                        result.Token = "tokent";
                        result.Id = user.UserId;
                        return result;
                    }else
                    {
                        result.Status = false;
                        result.Error = "Ошибка регистрации.";
                        return result;
                    }
                }catch(Exception e)
                {
                    result.Status = false;
                    result.Error = $"Произошла ошибка при регистрации: {e.Message}";
                    return result;
                }
                
            }else
            {
                result.Status = false;
                result.Error = $"Неизвестный аргумент: {typeLogin}";
                return result;
            }
        }

        private bool CheckOnline(string nickname) => _server.OnlineUsers.Any(u => u.Nickname == nickname);
    }
}

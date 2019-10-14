using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Core
{
    public class Login : IRequest
    {
        public string Trigger => "login";

        public string Execute(List<string> message)
        {
            string typeLogin = message[1];
            string nickname = message[2];
            string password = message[3];

            return null;
            //todo: сверяем логин  и пароль и регистрируем, если надо.
            //throw new NotImplementedException();
        }
    }
}

using Fooxboy.OldTanksServer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Interfaces.TanksApi
{
    public interface IAccount
    {
        bool Register(string nickname, string password, string email);
        bool CheckRegister(long userId);
        string GetNicknameFromId(long userId);
        long GetIdFromNickname(string nickname);
        User GetUserFromId(long id);
        bool SetUser(User user);
    }
}

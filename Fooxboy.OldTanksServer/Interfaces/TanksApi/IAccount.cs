using Fooxboy.OldTanksServer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Interfaces.TanksApi
{
    public interface IAccount
    {
        User Register(string nickname, string password, string email);
        bool CheckRegister(long userId);
        bool CheckRegister(string nickname);
        string GetNicknameFromId(long userId);
        long GetIdFromNickname(string nickname);
        User GetUserFromId(long id);
        bool SetUser(User user);
    }
}

using Fooxboy.OldTanksServer.Interfaces.TanksApi;
using Fooxboy.OldTanksServer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.TanksApi
{
    public class Account:IAccount
    {
        public bool CheckRegister(long userId)
        {
            throw new NotImplementedException();
        }

        public long GetIdFromNickname(string nickname)
        {
            throw new NotImplementedException();
        }

        public string GetNicknameFromId(long userId)
        {
            throw new NotImplementedException();
        }

        public User GetUserFromId(long id)
        {
            throw new NotImplementedException();
        }

        public Garage GetUserGarageFromId(long id)
        {
            throw new NotImplementedException();
        }

        public bool Register(string nickname, string password)
        {
            return true;
        }
    }
}

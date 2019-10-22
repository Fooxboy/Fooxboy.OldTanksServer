using Fooxboy.OldTanksServer.Database;
using Fooxboy.OldTanksServer.Interfaces.TanksApi;
using Fooxboy.OldTanksServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fooxboy.OldTanksServer.TanksApi
{
    public class Account:IAccount
    {
        public bool CheckRegister(long userId)
        {
            using(var db = new Database.ServerDB())
            {
                return db.Users.Any(u => u.UserId == userId);
            }
        }

        public bool CheckRegister(string nickname)
        {
            using (var db = new Database.ServerDB())
            {
                return db.Users.Any(u => u.Nickname == nickname);
            }
        }

        public long GetIdFromNickname(string nickname)
        {
            using var db = new ServerDB();
            var user = db.Users.Single(u => u.Nickname == nickname);
            return user is null ? 0 : user.UserId;
        }

        public string GetNicknameFromId(long userId)
        {
            using var db = new ServerDB();
            var user = db.Users.Single(u => u.UserId == userId);
            return user is null ? null : user.Nickname;
        }

        public User GetUserFromId(long userId)
        {
            using var db = new ServerDB();
            return db.Users.Single(u => u.UserId == userId);
        }
        public bool Register(string nickname, string password, string email)
        {
            using var db = new ServerDB();
            try
            {
                db.Users.Add(new User()
                {
                    Nickname = nickname,
                    Email = email,
                    IsBanned = false,
                    IsSpector = false,
                    Password = password,
                    UserId = 1
                });
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                //TODO: добавить агрументы.
                return false;
            }
        }

        public bool SetUser(User user)
        {
            using var db = new ServerDB();
            try
            {
                var currentUser = db.Users.Single(u => u.UserId == user.UserId);
                currentUser = user;
                db.SaveChanges();
                return true;

            }catch(Exception e)
            {
                return false;
            }
        }
    }
}

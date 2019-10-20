using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Models
{
    public class LoginResult
    {
        public bool Status { get; set; }
        public long Id { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string Error { get; set; }
    }
}

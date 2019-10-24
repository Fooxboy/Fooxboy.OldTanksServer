using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Fooxboy.OldTanksServer.Models
{
    public class User
    {
        [Key]
        public long UserId { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsBanned { get; set; }
        public bool IsBannedChat { get; set; }
        public bool IsSpector { get; set; }
        public long TypeUser { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Fooxboy.OldTanksServer.Models
{
    public class BannedIp
    {
        [Key]
        public long AddressId { get; set; }
        public string IP { get; set; }
        public string Nickname { get; set; }
        public string Reason { get; set; }
    }
}

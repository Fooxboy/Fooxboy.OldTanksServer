using System;
using System.Collections.Generic;
using System.Text;

namespace Fooxboy.OldTanksServer.Models
{
    public class ChatMessage
    {
        public long MessageId { get; set; }
        public string Text { get; set; }
        public string Rank { get; set; }
        public User User { get; set; }
        public DateTime Time { get; set; }
    }
}

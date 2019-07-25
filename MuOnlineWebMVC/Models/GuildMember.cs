using System;
using System.Collections.Generic;

namespace MuOnlineWebMVC.Models
{
    public partial class GuildMember
    {
        public string Name { get; set; }
        public string GName { get; set; }
        public byte? GLevel { get; set; }
        public byte GStatus { get; set; }
        public int GId { get; set; }
    }
}

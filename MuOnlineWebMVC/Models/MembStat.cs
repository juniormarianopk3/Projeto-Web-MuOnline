using System;
using System.Collections.Generic;

namespace MuOnlineWebMVC.Models
{
    public partial class MembStat
    {
        public string MembId { get; set; }
        public byte? ConnectStat { get; set; }
        public string ServerName { get; set; }
        public string Ip { get; set; }
        public DateTime? ConnectTm { get; set; }
        public DateTime? DisConnectTm { get; set; }
        public int? OnlineHours { get; set; }
    }
}

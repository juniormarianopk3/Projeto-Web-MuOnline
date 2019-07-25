using System;
using System.Collections.Generic;

namespace MuOnlineWebMVC.Models
{
    public partial class ExtWareHouse
    {
        public string AccountId { get; set; }
        public int Number { get; set; }
        public byte[] Items { get; set; }
        public int Money { get; set; }
        public DateTime? EndUseDate { get; set; }
        public byte? DbVersion { get; set; }
        public short? Pw { get; set; }
    }
}

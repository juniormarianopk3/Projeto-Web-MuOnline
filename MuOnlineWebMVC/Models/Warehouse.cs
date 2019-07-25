using System;
using System.Collections.Generic;

namespace MuOnlineWebMVC.Models
{
    public partial class Warehouse
    {
        public string AccountId { get; set; }
        public byte[] Items { get; set; }
        public int? Money { get; set; }
        public DateTime? EndUseDate { get; set; }
        public byte? DbVersion { get; set; }
        public short? Pw { get; set; }
        public int Vaults { get; set; }
        public int Number { get; set; }
        public int Total { get; set; }
    }
}

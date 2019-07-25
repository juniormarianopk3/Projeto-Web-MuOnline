using System;
using System.Collections.Generic;

namespace MuOnlineWebMVC.Models
{
    public partial class BlockingLog
    {
        public DateTime ApplDays { get; set; }
        public int AdminGuid { get; set; }
        public int BlockGuid { get; set; }
        public string DistCode { get; set; }
        public string AdminName { get; set; }
    }
}

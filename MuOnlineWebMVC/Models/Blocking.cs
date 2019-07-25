using System;
using System.Collections.Generic;

namespace MuOnlineWebMVC.Models
{
    public partial class Blocking
    {
        public int BlockGuid { get; set; }
        public int MembGuid { get; set; }
        public int ServGuid { get; set; }
        public string CharName { get; set; }
        public string TakeCode { get; set; }
        public string TakeCont { get; set; }
        public string MembCont { get; set; }
        public string ApplDays { get; set; }
        public string RelsDays { get; set; }
        public string Ctl1Code { get; set; }
    }
}

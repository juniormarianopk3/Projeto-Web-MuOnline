using System;
using System.Collections.Generic;

namespace MuOnlineWebMVC.Models
{
    public partial class Guild
    {
        public int GId { get; set; }
        public string GName { get; set; }
        public byte[] GMark { get; set; }
        public int? GScore { get; set; }
        public string GMaster { get; set; }
        public int? GCount { get; set; }
        public string GNotice { get; set; }
        public int Number { get; set; }
        public int GType { get; set; }
        public int GRival { get; set; }
        public int GUnion { get; set; }
        public int? MemberCount { get; set; }
        public int GScoreWeek { get; set; }
    }
}

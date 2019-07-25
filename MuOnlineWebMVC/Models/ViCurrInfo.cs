using System;
using System.Collections.Generic;

namespace MuOnlineWebMVC.Models
{
    public partial class ViCurrInfo
    {
        public string EndsDays { get; set; }
        public string ChekCode { get; set; }
        public int? UsedTime { get; set; }
        public string MembId { get; set; }
        public string MembName { get; set; }
        public int MembGuid { get; set; }
        public string SnoNumb { get; set; }
        public int? BillSection { get; set; }
        public int? BillValue { get; set; }
        public int? BillHour { get; set; }
        public int? SurplusPoint { get; set; }
        public DateTime? SurplusMinute { get; set; }
        public int? IncreaseDays { get; set; }
    }
}

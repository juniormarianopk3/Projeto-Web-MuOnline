using System;
using System.Collections.Generic;

namespace MuOnlineWebMVC.Models
{
    public partial class MembInfo
    {
        public int MembGuid { get; set; }
        public string MembId { get; set; }
        public string MembPwd { get; set; }
        public string MembName { get; set; }
        public string SnoNumb { get; set; }
        public string PostCode { get; set; }
        public string AddrInfo { get; set; }
        public string AddrDeta { get; set; }
        public string TelNumb { get; set; }
        public string PhonNumb { get; set; }
        public string MailAddr { get; set; }
        public string FpasQues { get; set; }
        public string FpasAnsw { get; set; }
        public string JobCode { get; set; }
        public DateTime? ApplDays { get; set; }
        public DateTime? ModiDays { get; set; }
        public DateTime? OutDays { get; set; }
        public DateTime? TrueDays { get; set; }
        public string MailChek { get; set; }
        public string BlocCode { get; set; }
        public string Ctl1Code { get; set; }
        public byte? VipFree { get; set; }
        public int? Member { get; set; }
        public int? Zy { get; set; }
        public int? Jf { get; set; }
        public int? Rcb { get; set; }
        public int? Vip { get; set; }
        public DateTime? Expired { get; set; }
        public string SmsT { get; set; }
        public string LastIp { get; set; }
        public string LastS { get; set; }
        public DateTime? BlocDate { get; set; }
        public int Cspoints { get; set; }
        public int Gold { get; set; }
        public int Cash { get; set; }
        public int VipTime { get; set; }
        public int VipBegin { get; set; }
        public int VipInteger { get; set; }
        public byte? AccountVip { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace MuOnlineWebMVC.Models
{
    public partial class OptionData
    {
        public string Name { get; set; }
        public byte[] SkillKey { get; set; }
        public byte? GameOption { get; set; }
        public byte? Qkey { get; set; }
        public byte? Wkey { get; set; }
        public byte? Ekey { get; set; }
        public byte? ChatWindow { get; set; }
    }
}

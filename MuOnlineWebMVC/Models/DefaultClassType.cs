using System;
using System.Collections.Generic;

namespace MuOnlineWebMVC.Models
{
    public partial class DefaultClassType
    {
        public byte Class { get; set; }
        public short? Strength { get; set; }
        public short? Dexterity { get; set; }
        public short? Vitality { get; set; }
        public short? Energy { get; set; }
        public byte[] Inventory { get; set; }
        public byte[] MagicList { get; set; }
        public float? Life { get; set; }
        public float? MaxLife { get; set; }
        public float? Mana { get; set; }
        public float? MaxMana { get; set; }
        public short? MapNumber { get; set; }
        public short? MapPosX { get; set; }
        public short? MapPosY { get; set; }
        public byte[] Quest { get; set; }
        public byte? DbVersion { get; set; }
        public short? Leadership { get; set; }
        public short? Level { get; set; }
        public short? LevelUpPoint { get; set; }
    }
}

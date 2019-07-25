using System;
using System.Collections.Generic;

namespace MuOnlineWebMVC.Models
{
    public partial class Character
    {
        public string AccountId { get; set; }
        public string Name { get; set; }
        public int? CLevel { get; set; }
        public int? LevelUpPoint { get; set; }
        public byte? Class { get; set; }
        public int? Experience { get; set; }
        public short? Strength { get; set; }
        public short? Dexterity { get; set; }
        public short? Vitality { get; set; }
        public short? Energy { get; set; }
        public byte[] Inventory { get; set; }
        public byte[] MagicList { get; set; }
        public int? Money { get; set; }
        public float? Life { get; set; }
        public float? MaxLife { get; set; }
        public float? Mana { get; set; }
        public float? MaxMana { get; set; }
        public short? MapNumber { get; set; }
        public short? MapPosX { get; set; }
        public short? MapPosY { get; set; }
        public byte? MapDir { get; set; }
        public int? PkCount { get; set; }
        public int? PkLevel { get; set; }
        public int? PkTime { get; set; }
        public DateTime? Mdate { get; set; }
        public DateTime? Ldate { get; set; }
        public byte? CtlCode { get; set; }
        public byte? DbVersion { get; set; }
        public byte[] Quest { get; set; }
        public short? Leadership { get; set; }
        public short? ChatLimitTime { get; set; }
        public int? FruitPoint { get; set; }
        public int Resets { get; set; }
        public int ResetsWeek { get; set; }
        public int MrTotal { get; set; }
        public int MrSemanal { get; set; }
        public int PkHeroTotal { get; set; }
        public int PkHeroSemanal { get; set; }
        public string Image { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuOnlineWebMVC.Models.ViewModels.PainelViewModels
{
    public class CharactersProfileViewModels
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
        public int? PkCount { get; set; }
        public int? PkLevel { get; set; }
        public int? PkTime { get; set; }
        public int Resets { get; set; }
        public int ResetsWeek { get; set; }
        public int MrTotal { get; set; }
        public int MrSemanal { get; set; }
        public int PkHeroTotal { get; set; }
        public int PkHeroSemanal { get; set; }
        public string Image { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace MuOnlineWebMVC.Models
{
    public partial class AccountCharacter
    {
        public int Number { get; set; }
        public string Id { get; set; }
        public string GameId1 { get; set; }
        public string GameId2 { get; set; }
        public string GameId3 { get; set; }
        public string GameId4 { get; set; }
        public string GameId5 { get; set; }
        public string GameIdc { get; set; }
        public byte? MoveCnt { get; set; }
    }
}

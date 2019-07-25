using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuOnlineWebMVC.Models.ViewModels.PainelViewModels
{
    public class ToChangeEmailViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string EmailComparable { get; set; }
        public string Pid {get;set;}
    }
}

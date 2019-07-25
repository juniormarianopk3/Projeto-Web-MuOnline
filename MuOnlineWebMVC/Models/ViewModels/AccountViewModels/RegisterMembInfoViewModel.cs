using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MuOnlineWebMVC.Models.AccountViewModels
{
    public class RegisterMembInfoViewModel
    {
        public int MembGuid { get; set; }        
       
        public string MembId { get; set; }

        
        public string MembPwd { get; set; }

       
        public string MembName { get; set; }

        public string SnoNumb { get; set; }

        public string MailAddr { get; set; }

    }
}

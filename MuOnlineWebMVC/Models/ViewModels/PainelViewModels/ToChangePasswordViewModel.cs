using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MuOnlineWebMVC.Models.ViewModels.PainelViewModels
{
    public partial class ToChangePasswordViewModel
    {
        public int Id { get; set; }
        public string ConfirmPassword { get; set; }
        public string Password { get; set; }

    }
}

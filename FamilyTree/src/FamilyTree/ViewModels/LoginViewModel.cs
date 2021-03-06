﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTree.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Användarnamn")]
        [Required(ErrorMessage = "Ange ett validerat användarnamn!")]
        public string UserName { get; set; }

        [Display(Name = "Lösenord")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Ange ett validerat Lösenord!")]
        public string Password { get; set; }
    }
}

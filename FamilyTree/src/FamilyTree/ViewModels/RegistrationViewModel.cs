using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTree.ViewModels
{
    public class RegistrationViewModel
    {

        [Display(Name = "Användarnamn")]
        [Required(ErrorMessage = "Ange ett användarnamn!")]
        public string UserName { get; set; }

        [Display(Name = "Lösenord")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Ange ett lösenord!")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Bekreft Lösenrod")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}

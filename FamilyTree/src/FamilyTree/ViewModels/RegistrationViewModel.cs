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
        [Required(ErrorMessage = "Ange Ett Användarnamn")]
        public string UserName { get; set; }

        [Display(Name = "Lösenord")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Ange ett lösenord")]
        public string Password { get; set; }
    }
}

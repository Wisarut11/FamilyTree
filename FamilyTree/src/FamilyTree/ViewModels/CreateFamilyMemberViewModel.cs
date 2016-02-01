using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTree.ViewModels
{
    public class CreateFamilyMemberViewModel
    {
        [Display(Name="Name of Family Member")]
        [Required(ErrorMessage ="Please add name of the family member")]
        public string Name { get; set; }
        [Display(Name="Relation of Family Member")]
        [Required(ErrorMessage="Please tell us how you are related to this person")]
        public string Relation { get; set; }
    }
}

using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FamilyTree.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            FamilyMembers = new List<FamilyMember>();
        }
        public List<FamilyMember> FamilyMembers { get; set; }
    }
}

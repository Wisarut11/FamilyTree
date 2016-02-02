using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTree.Models
{
    public class ftContext : IdentityDbContext<User>
    {
        public DbSet<FamilyMember> FamilyMembers { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}

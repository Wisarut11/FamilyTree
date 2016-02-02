using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTree.Models
{
    public class FamilyMember
    {
        public FamilyMember()
        {
            Images = new List<Image>();
        }
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Relation { get; set; }
        public List<Image> Images { get; set; }
    }
    public class Image
    {
        public int Id { get; set; }
        public string URI { get; set; }
        public string Text { get; set; }
        public int FamilyMemberId { get; set; }
    }
}

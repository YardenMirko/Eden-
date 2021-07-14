using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tryProject.Models
{
    public class ForumCategory
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Forum> Forums { get; set; }
    }
}

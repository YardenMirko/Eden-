using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tryProject.Models
{
    public class Zone
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string spName { get; set; } 
        public List<Association> Association { get; set; }
        public List<CommunityWorks> CommunityWorks { get; set; }

    }
}

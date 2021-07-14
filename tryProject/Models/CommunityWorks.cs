using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tryProject.Models
{
    public class CommunityWorks
    {
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Title")]
        public string Name { get; set; }
        [StringLength(500, MinimumLength =10)]
        [Required(ErrorMessage ="You must describe this work")]
        public string Decscription { get; set; }

        public Association Association { get; set; }
        public int AssociationId { get; set; }

        public Zone Zone { get; set; }
        public int ZoneId { get; set; }
        [Display(Name = "Caters To")]
        public CatersTo CatersTo { get; set; }
        public int CatersToId { get; set; }
        [Display(Name = "Seeking")]
        public WorkOrGive WorkOrGive { get; set; }
        public int WorkOrGiveId { get; set; }

        public string Location { get; set; }

    }
}

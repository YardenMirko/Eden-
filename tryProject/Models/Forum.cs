using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tryProject.Models
{
    public class Forum
    {
        public int Id { get; set; }


        public string Title { get; set; }

        public string Body { get; set; }
        public DateTime DatePublished { get; set; }

        public ForumCategory ForumCategory { get; set; }
        public int ForumCategoryId { get; set; }
        public List<Comment> Comments { get; set; }
        public List<ForumCategoryTag> ForumCategoryTags { get; set; }
    }
}

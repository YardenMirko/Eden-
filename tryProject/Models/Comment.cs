using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tryProject.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public Forum Forum { get; set; }
        public int ForumId { get; set; }
        public string Description { get; set; }
        public DateTime CommentDate { get; set; }
        public virtual ICollection<Remark> Remarks { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tryProject.Models
{
    public class Remark
    {
        public int Id { get; set; }
        public Comment Commet { get; set; }
        public int CommentId { get; set; }
        public string Body { get; set; }
        public DateTime RemarkTime { get; set; }
    }
}

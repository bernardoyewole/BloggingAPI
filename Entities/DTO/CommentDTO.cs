using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class CommentDTO
    {
        public int PostId { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime CommentDate { get; set; }
    }
}

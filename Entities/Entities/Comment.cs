using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }

        public string Author { get; set; }

        public string Content { get; set; }

        public DateTime CommentDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public DateTime PublishDate { get; set; }
    }
}

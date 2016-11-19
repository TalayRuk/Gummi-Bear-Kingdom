using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GummiBearKingdom.Models
{
    [Table("Topics")]
    public class Topic
    {
        [Key]
        public int TopicId { get; set; }
        public string Subject { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}

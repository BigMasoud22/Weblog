using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BlogAgg
{
    public class BlogImage
    {
        [Key]
        [ForeignKey("blog")]
        public int Id { get; set; }
        public string Title { get; set; }
        public string alttext { get; set; }
        public string imgAddress { get; set; }
        public virtual Blog blog { get; set; }
    }
}

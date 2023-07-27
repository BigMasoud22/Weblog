using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class BlogImage
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string alttext { get; set; }
        public string imgAddress { get; set; }
        public virtual Blog blog { get; set; }
    }
}

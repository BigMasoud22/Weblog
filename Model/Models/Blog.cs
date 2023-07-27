using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Description { get; set; }

        public DateTime ReleaseDate = DateTime.Now;

        //public virtual Articleimages? Articleimages { get; set; }
        public virtual User Author { get; set; }
    }
}

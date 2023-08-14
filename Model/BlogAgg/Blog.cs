using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Domain.UserAgg;

namespace Domain.BlogAgg
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
        public virtual BlogImage? image { get; set; }
    }
}

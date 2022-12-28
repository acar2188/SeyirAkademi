using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeyirAkademi_v1._1.Models
{
    public class Doc
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String ShortDescription { get; set; }
        public String Description { get; set; }
        public String ImageURL { get; set; }
        public String FileName { get; set; }
        public String FileURL { get; set; }

    }
}

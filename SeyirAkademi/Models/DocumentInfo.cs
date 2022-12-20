using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeyirAkademi.Models
{
    public class DocumentInfo
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime ChangeDateTime { get; set; }
        public bool ChangeInfo { get; set; }
        public string Contents { get; set; }
        public ICollection<File> Files { get; set; }

    }
}

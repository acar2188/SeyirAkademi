using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeyirAkademi_v1._1.Models
{
    public class Doc
    {
        public int Id { get; set; }
        public int DocTypeId { get; set; }
        public String Name { get; set; }
        public String ShortDescription { get; set; }
        public String Description { get; set; }
        public String ImageURL { get; set; }

        [NotMapped]
        public IFormFile UploadImage { get; set; }
        public String FileURL { get; set; }

        [NotMapped]
        public IFormFile UploadFile { get; set; }

        //public String FileName { get; set; }
        //public String FileURL { get; set; }

        //public ICollection<File> Files { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeyirAkademi_v1._1.Models
{
    public class File
    {

        [Key]
        public int FileID { get; set; }

        [Required(ErrorMessage = "Lütfen bir dosya adı giriniz")]
        [MaxLength(100)]
        [Display(Name = "Dosya Adı")]
        public String FileName { get; set; }

        [Required(ErrorMessage = "Lütfen bir dosya URL giriniz")]
        [MaxLength(200)]
        [Display(Name = "Dosya URL")]
        public String FileURL { get; set; }

        public int DocId { get; set; }
        public Doc Doc { get; set; }

    }
}

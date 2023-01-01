using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SeyirAkademi_v1._1.Models
{
    public class Doc
    {
        [Key]
        // Doc modeli ilk Create sayfasında oluşturulduğunda normalde id için key üretilmiyor. DB'ye yazarken üretiliyor.
        // Aşağıdaki komut ile kod içinde Key üretiliyor.
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen bir Doküman Kategorisi giriniz")]
        [Display(Name = "Docüman Kategorisi")]
        public int DocTypeId { get; set; }

        [Required(ErrorMessage = "Lütfen Doküman İsmi giriniz")]
        [MaxLength(20)]
        [Display(Name = "Doküman İsmi")]
        public String Name { get; set; }

        [MaxLength(50)]
        [Display(Name = "Kısa Açıklama")]
        public String ShortDescription { get; set; }

        [Required(ErrorMessage = "Lütfen Açıklama giriniz")]
        [Display(Name = "Doküman Açıklama")]
        public String Description { get; set; }


        public String ImageURL { get; set; }

        [Display(Name = "Doküman Görselini yükleyin")]
        [NotMapped]
        public IFormFile UploadImage { get; set; }
        public String FileURL { get; set; }

        [Display(Name = "İlgili Dosyayı Yükleyin")]
        [NotMapped]
        public IFormFile UploadFile { get; set; }

        //public int DocCategoryID { get; set; }
        //public DocCategory DocCategory { get; set; }

        //public String FileName { get; set; }
        //public String FileURL { get; set; }

        //public ICollection<File> Files { get; set; }

    }
}

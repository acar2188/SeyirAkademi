using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeyirAkademi_v1._1.Models
{
    public static class DocRepo
    {
        private static List<Doc> _Docs = null;


        static DocRepo()
        {
            _Docs = new List<Doc>()
            {
                new Doc() { Id=1, Name="Teknik Özellikler", ShortDescription ="Cihazın özelliklerini barındırır",ImageURL="1.png"},
                new Doc() { Id = 2, Name = "Kullanma Kılavuzu", ShortDescription = "Kullanma Kılavuzlarını barındırır",ImageURL="1.png"},
                new Doc() { Id = 2, Name = "Mekanik Detaylar", ShortDescription = "Mekanik Detaylar",ImageURL="1.png"},
                new Doc() { Id = 2, Name = "Sipariş Detayları", ShortDescription = "Sipariş Detayları",ImageURL="1.png"}

            };

        }

        public static List<Doc> Docs
        {
            get
            {
                return _Docs;
            }
        }


        public static void AddDoc(Doc entity)
        {
            _Docs.Add(entity);
        }
        public static Doc GetById(int id)
        {
            return _Docs.FirstOrDefault(i => i.Id == id);
        }


    }

}

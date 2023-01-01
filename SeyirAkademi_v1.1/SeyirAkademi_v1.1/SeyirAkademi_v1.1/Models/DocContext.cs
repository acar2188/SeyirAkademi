using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeyirAkademi_v1._1.Models
{
    public class DocContext:DbContext
    {

        public DbSet<Doc> Docs { get; set; }
        //public DbSet<DocCategory> DocCategories { get; set; }
        //public DbSet<File> Files { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=DocDB_3;Trusted_Connection=True;");
        }

    }
}

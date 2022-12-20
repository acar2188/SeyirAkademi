using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeyirAkademi.Models
{
    public class DocumentInfoContext:DbContext
    {
        public DbSet<File> Files { get; set; }
        public DbSet<DocumentInfo> Documents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=SeyirAkademiDb;Trusted_Connection=True;");
        }

    }
}

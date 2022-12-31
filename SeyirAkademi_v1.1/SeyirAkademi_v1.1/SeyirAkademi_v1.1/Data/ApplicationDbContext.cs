using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SeyirAkademi_v1._1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeyirAkademi_v1._1.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserDetail>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}

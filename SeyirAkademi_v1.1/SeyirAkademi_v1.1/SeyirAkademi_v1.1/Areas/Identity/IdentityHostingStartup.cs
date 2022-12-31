using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SeyirAkademi_v1._1.Data;
using SeyirAkademi_v1._1.Models;

[assembly: HostingStartup(typeof(SeyirAkademi_v1._1.Areas.Identity.IdentityHostingStartup))]
namespace SeyirAkademi_v1._1.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}
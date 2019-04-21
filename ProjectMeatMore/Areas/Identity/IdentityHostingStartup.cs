using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectMeatMore.Areas.Identity.Data;
using ProjectMeatMore.Models;

[assembly: HostingStartup(typeof(ProjectMeatMore.Areas.Identity.IdentityHostingStartup))]
namespace ProjectMeatMore.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<IdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("local")));

                services.AddDefaultIdentity<VisitorCredentials>()
                    .AddEntityFrameworkStores<IdentityContext>();
            });
        }
    }
}
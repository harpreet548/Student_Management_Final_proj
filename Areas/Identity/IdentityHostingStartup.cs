using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Student_Management_Final_proj.Models;

[assembly: HostingStartup(typeof(Student_Management_Final_proj.Areas.Identity.IdentityHostingStartup))]
namespace Student_Management_Final_proj.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Student_Management_IdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Student_Management_IdentityContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<Student_Management_IdentityContext>();
            });
        }
    }
}
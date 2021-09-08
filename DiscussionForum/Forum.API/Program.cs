using Forum.Application.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            CreateHostBuilder(args).Build();
                var app = CreateHostBuilder(args).Build();
            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                var userRole = await roleManager.FindByNameAsync(IdentityConstantHelper.UsersRoleConstans);
                if (userRole == null)
                {
                    var resultUser = await roleManager.CreateAsync(new IdentityRole(IdentityConstantHelper.UsersRoleConstans));
                    if (!resultUser.Succeeded)
                    {
                        throw new Exception(string.Join("\n", resultUser.Errors.Select(x => x.Description)));
                    }
                }
                var adminRole = await roleManager.FindByNameAsync(IdentityConstantHelper.AdminRoleConstans);
                if (adminRole == null)
                {
                    var resultAdmin = await roleManager.CreateAsync(new IdentityRole(IdentityConstantHelper.AdminRoleConstans));
                    if (!resultAdmin.Succeeded)
                    {
                        throw new Exception(string.Join("\n", resultAdmin.Errors.Select(x => x.Description)));
                    }
                }
                var user = new IdentityUser { UserName = "admin", Email = "secretAdmin@email.pl" };
                var check = await userManager.FindByEmailAsync(user.Email);
                if (check==null)
                {
                    var result = await userManager.CreateAsync(user, "adminPassword1234%");
                    await userManager.AddToRoleAsync(user, IdentityConstantHelper.AdminRoleConstans);
                }

            }


            app.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

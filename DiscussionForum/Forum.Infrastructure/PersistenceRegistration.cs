using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Forum.Persistence
{
    public static class PersistenceRegistration
    {
        public static IServiceCollection RegisterPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ForumDbContext>(options =>
                options.UseSqlServer(@"Server=DESKTOP-RN2H7NL;Database=APIForumDb;Trusted_Connection=True;MultipleActiveResultSets=True"));
         
            services.AddIdentity<IdentityUser, IdentityRole>(config =>
            {
                config.Password.RequiredLength = 8;
                config.Password.RequireDigit = true;
                config.Password.RequireNonAlphanumeric = true;
                config.Password.RequireUppercase = true;
            })
               .AddRoles<IdentityRole>()
               .AddEntityFrameworkStores<ForumDbContext>().AddDefaultTokenProviders();


            return services;
        }
    }
}

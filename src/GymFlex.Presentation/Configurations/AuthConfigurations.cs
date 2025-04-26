using GymFlex.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Identity;

namespace GymFlex.Presentation.Configurations
{
    public static class AuthConfigurations
    {
        public static IServiceCollection AddAndConfigureAuth(
            this IServiceCollection services
        )
        {
            services.AddAuthorization();
            services.ConfigureAuthentication();
            return services; 
        }

        private static IServiceCollection ConfigureAuthentication(
            this IServiceCollection services
        )
        {
            services.AddIdentityApiEndpoints<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            return services;
        }
    }
}
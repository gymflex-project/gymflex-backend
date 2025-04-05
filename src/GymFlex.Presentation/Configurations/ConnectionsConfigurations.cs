using GymFlex.Infrastructure.Data;
using GymFlex.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GymFlex.Presentation.Configurations
{
    public static class ConnectionsConfigurations
    {
        public static IServiceCollection AddAppConections(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.AddDbConnection(configuration);
            return services;
        }

        private static IServiceCollection AddDbConnection(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            var connectionString = configuration
                .GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString)
            );
            return services;
        }
    }
}


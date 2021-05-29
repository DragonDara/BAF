using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BAF.DataAccess.SqlServer
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddDataAccessSqlServer(this IServiceCollection services, string connectionString)
        {
            services
                .AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(connectionString));
            services.AddScoped<ApplicationDbContext>();
            return services;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            string connectionString = String.Format("server={0};user={1};database={2};port={3};password={4}", 
                "database-1.cfwggkma4p9f.us-east-2.rds.amazonaws.com", 
                "admin", 
                "paynau-technicaltest",
                3306, 
                "Admin123*");

            services.AddDbContext<PersonasDBContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            return services;
        }
    }
}

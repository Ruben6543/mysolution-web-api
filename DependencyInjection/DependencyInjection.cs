using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MySolution.Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySolution.Domain.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterSolutionResources(this IServiceCollection services, string dbConection)
        {
            services.AddDbContext<MySolutionDataContext>(options => options.UseSqlServer(dbConection, b => b.MigrationsAssembly("MySolution.Infraestructure")));
            services.AddScoped<DbContext, MySolutionDataContext>();

            return services;
        }
    }
}

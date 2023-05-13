using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MySolution.Domain.Infraestructure;
using MySolution.Domain.Services;
using MySolution.Infraestructure;
using MySolution.Infraestructure.Entities;
using MySolution.Infraestructure.Infraestructure;
using MySolution.Infraestructure.Repository;
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

            services.AddScoped<IRepository<MySolutionDataContext, MusicEntity>, Repository<MySolutionDataContext, MusicEntity>>();
            services.AddScoped<IMusicService, MusicService>();

            return services;
        }
    }
}

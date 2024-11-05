using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Application.Interfaces.Repositories;
using Ecommerce.Persistence.Repositories;
using Ecommerce.Application.Interfaces.UnitOfWorks;
using Ecommerce.Persistence.UnitOfWorks;

namespace Ecommerce.Persistence
{
    public static class Registiration
    {
        public static void AddPersistence(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
       
    }
}

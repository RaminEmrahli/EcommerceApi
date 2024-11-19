
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApi.Mapper
{
    public static class Registiration
    {
        public static void AddCustomMapper(this IServiceCollection services)
        {
            services.AddSingleton<Ecommerce.Application.Interfaces.AutoMapper.IMapper, AutoMapper.Mapper>();
            
        }
    }
}

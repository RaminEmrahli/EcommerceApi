using Ecommerce.Application.Bases;
using Ecommerce.Application.Behaviours;
using Ecommerce.Application.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application
{
    public static class Registiration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            
            services.AddTransient<ExceptionMiddleware>();
            services.AddRulesFromAssemblyContaining(assembly,typeof(BaseRules));
            
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
            
            services.AddValidatorsFromAssembly(assembly);
            
            ValidatorOptions.Global.LanguageManager.Culture=new CultureInfo("az");

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RedisCacheBehaviour<,>));
        }
        private static IServiceCollection AddRulesFromAssemblyContaining(this IServiceCollection services,Assembly assembly,Type type)
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t);
            foreach(var item in types)
            {
                services.AddTransient(item);
            }
            return services;
        }
    }
}

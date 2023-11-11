using Business.Abstract;
using Business.Concrete;
using Business.Logger;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    public static class AutomapperServiceRegistration
    {
        public static void AddAutomapperServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(assembly);
            //services.AddScoped<IBookService, BookManager>();
            //services.AddScoped<ICategoryService, CategoryManager>();
            //services.AddSingleton<ILoggerService, LoggerManager>();
        }
    }
}

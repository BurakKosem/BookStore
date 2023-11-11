using Business.Abstract;
using Business.ActionFilters;
using Business.Auth;
using Business.Concrete;
using Business.Logger;
using Business.Validations;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace WebAPI.Extensions
{
    public static class BusinessServiceRegistrations
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(assembly);
            services.AddScoped<IBookService, BookManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddSingleton<ILoggerService, LoggerManager>();
            services.AddScoped<IAuthenticationService, AuthenticationManager>();
            services.AddSingleton<LogFilterAttribute>();
            services.AddControllers()
                .AddFluentValidation(option =>
            {
                option.RegisterValidatorsFromAssemblyContaining<BookValidation>();
                option.DisableDataAnnotationsValidation = true;
            });

            return services;
        }
    }
}

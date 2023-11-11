using AspNetCoreRateLimit;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Extensions
{
    public static class APIServiceRegistrations
    {
        public static IServiceCollection AddAPIServices(this IServiceCollection services)
        {
            
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
            });

            services.AddResponseCaching();

            //services.AddHttpCacheHeaders(
            //    (expirationModelOptions) =>
            //    {
            //        expirationModelOptions.MaxAge = 60;
            //    },
            //    (validationModelOptions) =>
            //    {
            //        validationModelOptions.MustRevalidate = true;
            //    });

            var rateLimitRules = new List<RateLimitRule>()
            {
                new RateLimitRule()
                {
                    Endpoint = "*",
                    Limit = 3,
                    Period = "10s"
                }
            };

            services.Configure<IpRateLimitOptions>(option =>
            {
                option.GeneralRules = rateLimitRules;
            });

            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();

            return services;
        }
    }
}

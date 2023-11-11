using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Extensions
{
    public static class DataAccessServiceRegitrations
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("MSSQL");
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));
            services.AddDistributedMemoryCache();
            services.AddScoped<IBookDal, BookDal>();
            services.AddScoped<ICategoryDal, CategoryDal>();

            return services;
        }
    }
}

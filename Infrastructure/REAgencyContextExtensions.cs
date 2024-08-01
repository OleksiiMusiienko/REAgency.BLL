using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using REAgency.DAL.EF;

namespace REAgency.BLL.Infrastructure
{
    public static class REAgencyContextExtensions
    {
        public static void AddREAgencyContext(this IServiceCollection services, string connection)
        {

            services.AddDbContext<REAgencyContext>(options => options.UseSqlServer(connection));
        }
    }
}

using Application_Contracts.Application_Blog;
using Domain.BlogAgg;
using Domain.UserAgg;
using Infrastructure.ServiceIMP;
using Microsoft.Extensions.DependencyInjection;
using Application;

namespace Infrastructure
{
    public class DIServices
    {
        public static void Configure(IServiceCollection service)
        {
            service.AddScoped<IUserServices, UserServices>();
            service.AddScoped<IBlogServices, BlogServices>();
            service.AddScoped<IBlogApplication, BlogApplication>();
        }
    }
}

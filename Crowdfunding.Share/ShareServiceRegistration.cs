using Crowdfunding.Share.Utility;
using Crowdfunding.Share.Utility.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Share
{
    public static class ShareServiceRegistration
    {
        public static IServiceCollection AddShareServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IHttpRequest, HttpRequest>();
            services.AddSingleton<Cryptography>();

            return services;
        }
    }
}

using Crowdfunding.Database.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Database
{
    public static class DatabaseRegistraction
    {
        public static IServiceCollection AddDataBaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region DB Context
            services.AddDbContext<DatabaseContext>();
            #endregion

            return services;
        }
    }
}

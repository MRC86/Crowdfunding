using Crowdfunding.Infrastructure.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Infrastructure
{
    public static class InfrastructureRegistraction
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region 資料表的Repository
            services.AddScoped<CommentRepository>();
            services.AddScoped<FavoriteRepository>();
            services.AddScoped<InvestItemRepository>();
            services.AddScoped<NewsRepository>();
            services.AddScoped<ProjectImageRepository>();
            services.AddScoped<ProjectRepository>();
            services.AddScoped<ProjectTypeRepository>();
            services.AddScoped<QuestionRepository>();
            services.AddScoped<SuperCommentRepository>();
            services.AddScoped<UserRepository>();
            #endregion

            return services;
        }
    }
}

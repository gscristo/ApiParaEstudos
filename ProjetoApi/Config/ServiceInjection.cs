using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DataAccess.Context;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Core.Interfaces;
using Core;
using Core.Users;
using Core.Users.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using SocialAuth.Core;
using SocialAuth.Model;
using Api.SocialAuth.Interfaces;
using Api.SocialAuth.Core;

namespace Api.Config
{
    public class ServiceInjection
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            var databaseSettings = configuration.GetSection("DatabaseSettings");

            #region GeneralSettings         
            
            services.AddTransient<IConfigureOptions<JwtBearerOptions>, ConfigureJwtBearerOptions>();
            services.AddSingleton<IConfiguration>(configuration);
            services.Configure<AuthSettings>(configuration.GetSection("AuthSettings"));

            #endregion

            #region  DataAccess

            services.AddSingleton<IDataContext>(serviceProvider => new DataContext(databaseSettings["ProjetoApiSqlConnection"]));
            services.AddScoped<IUsersRepository, UsersRepository>();

            #endregion

            #region Core Services

            services.AddScoped<ICreateUsers, CreateUsers>();
            services.AddScoped<IUpdateUsers, UpdateUsers>();
            services.AddScoped<IDeleteUsers, DeleteUsers>();
            services.AddScoped<IGetAllUsers, GetAllUsers>();
            services.AddScoped<IGetUsersById, GetUsersById>();
            services.AddScoped<IJwtGenerator, JwtGenerator>();
            services.AddScoped<ILogin, Login>();

            #endregion

        }
    }
}

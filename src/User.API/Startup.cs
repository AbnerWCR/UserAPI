using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using User.API.ViewModels;
using User.Domain.Interfaces;
using User.Domain.Interfaces.Services;
using User.Infra.Data.Context;
using User.Infra.Data.Repository;
using User.Services.DTOs;
using User.Services.Services;

namespace User.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<UserContext>(options => 
                options.UseMySql(
                    connectionString: Configuration.GetConnectionString("default"), 
                    serverVersion: new MySqlServerVersion(new Version(8, 0))
            ));


            #region AutoMapper

            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Domain.Entities.User, UserDTO>().ReverseMap();
                cfg.CreateMap<CreateUserViewModel, UserDTO>().ReverseMap();
                cfg.CreateMap<UpdateUserViewModel, UserDTO>().ReverseMap();
                cfg.CreateMap<ChangePasswordViewModel, UserDTO>().ReverseMap();
            });

            #region DependenceInjection

            services.AddSingleton(autoMapperConfig.CreateMapper());
            services.AddScoped<IBaseRepository<Domain.Entities.User>, BaseRepository<Domain.Entities.User>>();
            services.AddScoped<IBaseService<Domain.Entities.User>, BaseService<Domain.Entities.User>>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            #endregion



            #endregion
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WishList.Core.Models;
using WishList.Core.Services;
using WishList.Core.Validations.UserValidations;
using WishList.Core.Validations.WishValidations;
using WishList.Data;
using WishList.Services;

namespace WishList
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WishList", Version = "v1" });
            });

            var connectionString = Configuration.GetConnectionString("Wish-List");

            services.AddDbContext<WishListDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IWishListDbContext, WishListDbContext>();
            services.AddScoped<IDbService, DbService>();

            services.AddScoped<IEntityService<Wish>, EntityService<Wish>>();

            services.AddScoped<IWishService, WishService>();
            services.AddScoped<IWishDescriptionValidator, WishDescriptionValidator>();

            services.AddScoped<IUserValidations, UserNameValidator>();
            services.AddScoped<IUserValidations, UserEmailValidator>();
            services.AddScoped<IUserValidations, UserTypeValidator>();

            services.AddSingleton<IMapper>(AutoMapperConfig.CreateMapper());
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WishList v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using Contact.API.Dtos;
using Contact.API.Filters;
using Contact.Core.Contracts;
using Contact.Core.Contracts.Repositories;
using Contact.Core.Contracts.Services;
using Contact.Data;
using Contact.Data.Repositories;
using Contact.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MainContext>(options =>
            {
                options.UseNpgsql(Configuration["ConnectionStrings:DefaultConnection"].ToString(), o =>
                {
                    o.MigrationsAssembly("Contact.Data");
                });
            });

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<ContactNotFoundFilter>();

            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddControllers(options =>
            {
                options.Filters.Add(new ValidationFilter());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Contact.API", Version = "v1" });
            });
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contact.API v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (errorFeature != null)
                    {
                        var errorResponse = new ResponseDto();
                        var ex = errorFeature.Error;
                        errorResponse.Errors.Add(ex.Message);
                        errorResponse.Success = false;
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
                    }
                });
            });

        }
    }
}

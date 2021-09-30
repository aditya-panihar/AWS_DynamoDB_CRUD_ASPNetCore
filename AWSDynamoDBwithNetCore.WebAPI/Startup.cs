using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.Runtime;
using AWSDynamoDBwithNetCore.Domain.Services.Interfaces.Repositories;
using AWSDynamoDBwithNetCore.Domain.Services.Interfaces.Services;
using AWSDynamoDBwithNetCore.Domain.Services.Services;
using AWSDynamoDBwithNetCore.Infrastructure.Persistence;
using AWSDynamoDBwithNetCore.Infrastructure.Persistence.Repositories;
using AWSDynamoDBwithNetCore.WebAPI.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace AWSDynamoDBwithNetCore.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", builder => builder.WithOrigins("https://localhost:44309/"));
            });
            services.AddControllers(config =>
            {
                config.Filters.Add(typeof(ResponseTimeActionFilter));
            });
            var accessKey = Configuration.GetValue<string>("AWSDynamoDb:Configuration:AccessKey");
            var secretKey = Configuration.GetValue<string>("AWSDynamoDb:Configuration:SecretKey");

            services.AddSingleton<IAmazonDynamoDB>(sp =>
            {
                return new AmazonDynamoDBClient(accessKey, secretKey, RegionEndpoint.USEast2);
            });
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Product service API",
                    Version = "v1",
                    Description = "Sample service for Product API"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Product services");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Welcome to running ASP.NET Core on AWS Lambda");
                //});
            });
        }
    }
}

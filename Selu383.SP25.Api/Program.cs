using Microsoft.AspNetCore.Builder;
//using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Selu383.SP25.Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Selu383.SP25.Api.Data;
using Selu383.SP25.Api.Entities;
using Selu383.SP25.Api.Seeding;

namespace Selu383.SP25.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddDbContext<DataContext>;
            builder.Services.AddScopeed<DbInitializer>;
           

            var app = builder.Build();

       
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiRefrence();
                app.UseItToSeedSqlServer();
              
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

    }
}

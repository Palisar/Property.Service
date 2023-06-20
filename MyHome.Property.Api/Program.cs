
using MyHome.Common;
using MyHome.Property.Business.Interfaces;
using MyHome.Property.Business.Services;
using MyHome.Property.DAL;
using MyHome.Property.Entities.Entities;

namespace MyHome.Property.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IPropertyService, PropertyService>();
            //NOTE : Made this singleton for example purposes only.
            builder.Services.AddSingleton<IRepository<PropertyModel>, InMemoryPropertyDatabase>();

            //builder.Services.AddTransient<IRepository<PropertyModel>, InMemoryPropertyDatabase>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }

}
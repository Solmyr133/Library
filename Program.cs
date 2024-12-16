using library.Models;
using Lorincz_Lorand_backend.Repositories.Interfaces;
using Lorincz_Lorand_backend.Repositories.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace library
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IAuthorInterface, AuthorService>();
            builder.Services.AddScoped<IBookInterface, BookService>();
            builder.Services.AddScoped<ICategoryInterface, CategoryService>();

            builder.Services.AddDbContext<LibrarydbContext>(option =>
            {
                var connectionString = builder.Configuration.GetConnectionString("MySql");
                option.UseMySQL(connectionString);
            });

            builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            builder.Services.AddCors(c => { c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); });

            var app = builder.Build();

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

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

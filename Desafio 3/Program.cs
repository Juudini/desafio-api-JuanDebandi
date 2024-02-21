using Desafio_3.database;
using Desafio_3.service;
using Desafio_3.Services;
using Microsoft.EntityFrameworkCore;

namespace Desafio_3
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

            builder.Services.AddDbContext<CoderContext>( options =>
            {
                options.UseSqlServer("Server=.; Database=coderhouse; Trusted_Connection=True;");
             });

            builder.Services.AddScoped<UsuarioService>();
            builder.Services.AddScoped<ProductoService>();
            builder.Services.AddScoped<ProductoVendidoService>();
            builder.Services.AddScoped<VentaServices>();

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

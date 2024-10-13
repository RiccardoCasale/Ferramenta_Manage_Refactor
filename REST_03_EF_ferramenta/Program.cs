
using Microsoft.EntityFrameworkCore;
using REST_03_EF_ferramenta.Models;
using REST_03_EF_ferramenta.Repositories;
using REST_03_EF_ferramenta.Services;

namespace REST_03_EF_ferramenta
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

            #region settare il comportamento dei componenti

#if DEBUG

            builder.Services.AddDbContext<Context_Ferramenta>(
               options => options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseTest"))
               );

            builder.Services.AddScoped<ProdottoRepository>();
            builder.Services.AddScoped<RepartoRepository>();
            builder.Services.AddScoped<ProdottoService>();
            builder.Services.AddScoped<RepartoService>();

            #else

#endif
#endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.UseCors(builder =>
                 builder
                 .WithOrigins("*")
                 .AllowAnyMethod()
                 .AllowAnyHeader());

            app.Run();
        }
    }
}

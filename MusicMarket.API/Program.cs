using Microsoft.EntityFrameworkCore;
using MusicMarket.Core;
using MusicMarket.Core.Services;
using MusicMarket.Data;
using MusicMarket.Services;
using System.Reflection;

namespace MusicMarket.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<MusicMarketDBContext>(opt=>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("connectionString"),x=>x.MigrationsAssembly("MusicMarket.Data")); //todo:Sonrasýnda tekrar detaylandýr
            });
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddTransient<IMusicService, MusicService>();
            builder.Services.AddTransient<IArtistService,ArtistService>();

            //builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
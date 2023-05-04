using Microsoft.Extensions.DependencyInjection;
using MusicMarket.Services.Abstract;
using MusicMarket.Core;
using MusicMarket.Data;
using Microsoft.EntityFrameworkCore;

namespace MusicMarket.Services.DependencyExtension.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<MusicMarketDBContext>(opt =>
           {
               opt.UseSqlServer("Server=YUSATOSUN\\SQLEXPRESS;Database=MusicMarketDB;Trusted_Connection=True"); 
           });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IMusicService, MusicService>();
            services.AddTransient<IArtistService, ArtistService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}

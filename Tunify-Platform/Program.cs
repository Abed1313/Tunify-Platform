using Microsoft.EntityFrameworkCore;
using Tunify_Platform.data;
using Tunify_Platform.Repositories.Interfaces;
using Tunify_Platform.Repositories.Servises;

namespace Tunify_Platform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Configure the database context.
            string BuilderVar = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<TunifyDbContext>(optionX => optionX.UseSqlServer(BuilderVar));


            // Register repositories.    
            builder.Services.AddScoped<IArtists, ArtistsServises>();
            builder.Services.AddScoped<IPlaylist, PlaylistServises>();
            builder.Services.AddScoped<ISongs, SongsServises>();
            builder.Services.AddScoped<IUsers, UsersServises>();

            var app = builder.Build();
            app.MapControllers();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
        
    }
}

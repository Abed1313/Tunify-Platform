using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Tunify_Platform.data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Interfaces;
using Tunify_Platform.Repositories.Services;
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

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<TunifyDbContext>()
                ;


            // Register repositories.    
            builder.Services.AddScoped<IArtists, ArtistsServises>();
            builder.Services.AddScoped<IPlaylist, PlaylistServises>();
            builder.Services.AddScoped<ISongs, SongsServises>();
            builder.Services.AddScoped<IUsers, UsersServises>();
            builder.Services.AddScoped<IUser, IdentityUserService>();
            builder.Services.AddScoped<JwtTokenServeses>();

            //Add auth serveces to the app using JWT
            builder.Services.AddAuthentication(
                options =>
                {
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }
                ).AddJwtBearer(
                options =>
                {
                    options.TokenValidationParameters = JwtTokenServeses.ValidateToken(builder.Configuration);
                });

            // Define a policy     ||[Policy-Based Authorization]||
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("ThisEmailOnly", policy => policy.RequireClaim("Email", "abedradwan84.5@gmail.com"));
            });

            //swagger configuration
            builder.Services.AddSwaggerGen
                (

                option =>
                {
                    option.SwaggerDoc("TunifyPlatformAPI", new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "Tunify Platform Api Doc",
                        Version = "v1",
                        Description = "Api for managing all Tunify Platform"
                    });

                    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Name = "Authorization",
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer",
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                        Description = "Please enter user token below."
                    });

                    option.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            Array.Empty<string>()
                        }
                    });
                });

            var app = builder.Build();

            app.UseAuthentication();
            app.UseAuthorization();

            // call swagger service
            app.UseSwagger
                (
                options =>
                {
                    options.RouteTemplate = "api/{documentName}/swagger.json";
                }
                );

            // call swagger UI
            app.UseSwaggerUI
                (
                options =>
                {
                    options.SwaggerEndpoint("/api/TunifyPlatformAPI/swagger.json", "TP Api");
                    options.RoutePrefix = "";
                }
                );

            
            app.MapControllers();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
        
    }
}

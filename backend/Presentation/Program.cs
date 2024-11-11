using Core.Repositories;
using Core.Services;
using Application.Services;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Data;
using Presentation.Services;
using Infrastructure.Services;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text;


namespace Presentation
{
    public class Program
    {
        private static void ConfigurarSwagger(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
                        {
                            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Orders Manager API", Version = "v1" });
                            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                            {
                                Name = "Authorization",
                                Type = SecuritySchemeType.Http,
                                Scheme = "Bearer",
                                BearerFormat = "JWT",
                                In = ParameterLocation.Header
                            });
                            c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
        }

        private static void InjetarDependeciaRepositorio(IHostApplicationBuilder builder)
        {
            string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<EficazesDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );
        }

        private static void AdicionarControladoreseDependecias(IHostApplicationBuilder builder)
        {
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

            builder.Services.AddScoped<IClienteService, ClienteService>();
            builder.Services.AddScoped<IEnderecoService, EnderecoService>();
            builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
            builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IAuthRepository, AuthRepository>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<IImagemService, ImagemService>();
        }

        private static void InitializeSwagger(WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        private static void Authentication(IHostApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SECRET_KEY"]!))
                    };
                });
            builder.Services.AddAuthorization();
        }

        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            ConfigurarSwagger(builder.Services);
            InjetarDependeciaRepositorio(builder);
            AdicionarControladoreseDependecias(builder);
            Authentication(builder);

            WebApplication app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                InitializeSwagger(app);
            }

            app.UseCors();
            app.MapControllers();

            app.UseStaticFiles();

            app.Run();
        }
    }
}

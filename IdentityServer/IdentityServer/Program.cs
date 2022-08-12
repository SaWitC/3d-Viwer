using Application.Repositories;
using DataAcces.Models;
using DataAcces.SettingAndOptionModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistence.Repository;

namespace IdentityServer
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IAccountRepository, AccountRepository>();

            var authOptions = builder.Configuration.GetSection("Auth");
            builder.Services.Configure<AuthOptions>(authOptions);

            var AuthOptionsForVlidation = builder.Configuration.GetSection("Auth").Get<AuthOptions>();
            //builder.Services.AddScoped<IApplicationBuilder, ApplicationBuilder>();  

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddIdentity<User,IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = true;
                o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    IssuerSigningKey = AuthOptionsForVlidation.GetSymetricSecurityKey(),
                    ValidIssuer = AuthOptionsForVlidation.Issuer,
                    ValidAudience = AuthOptionsForVlidation.Audience
                };

            });

            var app = builder.Build();

            try
            {
                using (var scope = app.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;

                    var context = services.GetRequiredService<AppDbContext>();

                    if (context.Database.IsSqlServer())
                    {
                        context.Database.Migrate();
                    }

                    var UserManager = services.GetRequiredService<UserManager<User>>();
                    var RoleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    await SetSampleData.Initialize(UserManager, RoleManager);
                }
            }
            catch
            {

            }
 
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseCors(o =>
            {
                o.AllowAnyMethod();
                o.AllowAnyHeader();
                o.AllowAnyOrigin();
            });

            app.MapControllers();

            app.Run();
        }
    }
}
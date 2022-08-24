using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Resource3dModelsApi.Application.Repository;
using Resource3dModelsApi.Application.Services.FileResourceServices;
using Resource3dModelsApi.Domain.ConfigurationModels;
using Resource3dModelsApi.Infrastructure.Data;
using Resource3dModelsApi.Infrastructure.Repository;
using Resource3dModelsApi.Infrastructure.Services;
using Resource3dModelsApi.Infrastructure.ValidationPipeline;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//main
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//validation
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>),typeof(ValidationBehavior<,>));
//repositories
builder.Services.AddTransient<IBaseRepository, BaseRepository>();
builder.Services.AddTransient<ISelectRepository, SelectRepository>();
//services
builder.Services.AddTransient<IFileResourceService, YandexFileResourceService>();
//databse
builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//mediatr
builder.Services.AddMediatR(typeof(Resource3dModelsApi.Infrastructure.Startup).Assembly);
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
//automapper
builder.Services.AddAutoMapper(typeof(Resource3dModelsApi.Infrastructure.Startup));


var authOptions =builder.Configuration.GetSection("Auth").Get<AuthModel>();

builder.Services.Configure<FormOptions>(o =>
{
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBoundaryLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = authOptions.Issuer,

        ValidateAudience = true,
        ValidAudience = authOptions.Audience,

        ValidateLifetime = true,

        IssuerSigningKey = authOptions.GetSymetricSecurityKey(),
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddCors(o =>
{
    o.AddPolicy("test", p =>
    {
        p.AllowAnyHeader();
        p.AllowAnyMethod();
        p.AllowAnyOrigin();
    });
});


var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    try
    {
        var services = scope.ServiceProvider;

        var context = services.GetRequiredService<AppDbContext>();

        await SampleData.Initialize(context);
    }
    catch
    {

    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors("test");

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

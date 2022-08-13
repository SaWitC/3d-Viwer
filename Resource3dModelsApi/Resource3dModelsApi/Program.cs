using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Resource3dModelsApi.Application.Repository;
using Resource3dModelsApi.Infrastructure.Data;
using Resource3dModelsApi.Infrastructure.Repository;
using Resource3dModelsApi.Infrastructure.ValidationPipeline;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddValidatorsFromAssembly(typeof(Resource3dModelsApi.Infrastructure.Startup).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>),typeof(ValidationBehavior<,>));

builder.Services.AddTransient<IBaseRepository, BaseRepository>();

builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddMediatR(typeof(Resource3dModelsApi.Infrastructure.Startup).Assembly);
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());


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

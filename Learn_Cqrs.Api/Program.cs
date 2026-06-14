using FluentValidation;
using Learn_Cqrs.Application;
using Learn_Cqrs.Application.Behavior;
using Learn_Cqrs.Application.Common.Interfaces;
using Learn_Cqrs.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
// we register MediatR, FluentValidation, and our custom validation behavior in the dependency injection container.
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(IAssemblyMarker).Assembly)); 
builder.Services.AddValidatorsFromAssembly(typeof(IAssemblyMarker).Assembly);
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=app.db"));
builder.Services.AddScoped<IAppDbContext , AppDbContext>(); 

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

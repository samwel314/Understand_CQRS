using FluentValidation;
using Learn_Cqrs.Application;
using Learn_Cqrs.Application.Behavior;
using Learn_Cqrs.Application.Common.Interfaces;
using Learn_Cqrs.Application.Todos.Commands.CreateTodo;
using Learn_Cqrs.Application.Todos.Queries.GetTodos;
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
var api = app.MapGroup("/api"); 

var todosGroup = api.MapGroup("/todos");
todosGroup.MapGet("/", async (IMediator mediator) =>
{
   var result = await  mediator.Send(new GetTodosQuery()); 
   return TypedResults.Ok(result);  
});

todosGroup.MapGet("/{id:guid}", async (IMediator mediator, Guid id)  =>
{
    var result = await mediator.Send(new GetTodoQuery (id));
    return result is null ? Results.NotFound() : TypedResults.Ok(result);
});

todosGroup.MapPost("/", async (IMediator mediator , CreateTodoCommand command) =>
{
    var result = await mediator.Send(command);
    return TypedResults.Ok( new
    {
        Id = result 
    });
});


todosGroup.MapDelete("/{id:guid}", async (IMediator mediator, Guid id) =>
{
   await mediator.Send(new DeleteTodoCommand(id)  );
    return TypedResults.Ok(); 
});
todosGroup.MapPut("/", async (IMediator mediator, UpdateTodoCommand command) =>
{
    await mediator.Send( command);
    return TypedResults.Ok();
});
app.Run();

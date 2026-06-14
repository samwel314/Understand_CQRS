using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Learn_Cqrs.Application.Todos.Commands.CreateTodo
{
    public sealed record UpdateTodoCommand(Guid  Id  , string Title , bool Completed) : IRequest;  

}

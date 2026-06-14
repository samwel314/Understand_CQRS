using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Learn_Cqrs.Application.Todos.Commands.CreateTodo
{
    public sealed record DeleteTodoCommand(Guid  Id ) : IRequest;  

}

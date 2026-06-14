using Learn_Cqrs.Domain.Todos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Learn_Cqrs.Application.Todos.Queries.GetTodos
{
    public sealed record GetTodoQuery(Guid Id ) : IRequest<Todo?> ;
}

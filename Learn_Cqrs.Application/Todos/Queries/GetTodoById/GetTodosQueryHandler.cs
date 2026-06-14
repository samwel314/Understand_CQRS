using Learn_Cqrs.Application.Common.Interfaces;
using Learn_Cqrs.Domain.Todos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Learn_Cqrs.Application.Todos.Queries.GetTodos
{
    public sealed class  GetTodoQueryHandler : IRequestHandler<GetTodoQuery, Todo?>
    {
        private readonly IAppDbContext  _db;
        public GetTodoQueryHandler(IAppDbContext db)
        {
            _db = db    ;
        }
        public async Task<Todo?> Handle(GetTodoQuery request, CancellationToken cancellationToken)
        {
            return await _db.Todos.FindAsync(request.Id, cancellationToken);
        }
    }
}

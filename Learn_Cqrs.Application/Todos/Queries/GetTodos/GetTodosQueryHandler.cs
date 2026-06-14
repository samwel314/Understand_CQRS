using Learn_Cqrs.Application.Common.Interfaces;
using Learn_Cqrs.Domain.Todos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Learn_Cqrs.Application.Todos.Queries.GetTodos
{
    public sealed class  GetTodosQueryHandler : IRequestHandler<GetTodosQuery, List<Todo>>
    {
        private readonly IAppDbContext  _db;
        public GetTodosQueryHandler(IAppDbContext db)
        {
            _db = db    ;
        }
        public async Task<List<Todo>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
        {
            return await _db.Todos.ToListAsync  (cancellationToken);
        }
    }
}

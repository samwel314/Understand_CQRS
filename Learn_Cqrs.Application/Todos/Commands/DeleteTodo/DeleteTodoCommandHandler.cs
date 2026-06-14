using Learn_Cqrs.Application.Common.Interfaces;
using Learn_Cqrs.Domain.Todos;
using MediatR;

namespace Learn_Cqrs.Application.Todos.Commands.CreateTodo
{
    public sealed class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand>
    {
        private readonly IAppDbContext _db;

        public DeleteTodoCommandHandler (IAppDbContext db)
        {
            _db = db;
        }

        public async Task Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
        {
           var todo =  await _db.Todos.FindAsync(request.Id ,cancellationToken ); 

             if (todo == null)
             {
                 throw new KeyNotFoundException($"Todo with Id {request.Id} not found.");
             }
             _db.Todos.Remove(todo);        
            await _db.SaveChangesAsync(cancellationToken);
        }

    }
}

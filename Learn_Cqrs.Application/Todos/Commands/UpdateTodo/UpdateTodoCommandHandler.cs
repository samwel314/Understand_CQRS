using Learn_Cqrs.Application.Common.Interfaces;
using Learn_Cqrs.Domain.Todos;
using MediatR;

namespace Learn_Cqrs.Application.Todos.Commands.CreateTodo
{
    public sealed class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand>
    {
        private readonly IAppDbContext _db;

        public UpdateTodoCommandHandler(IAppDbContext db)
        {
            _db = db;
        }

        public async Task Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
        {
           var todo =  await _db.Todos.FindAsync(request.Id ,cancellationToken ); 

             if (todo == null)
             {
                 throw new KeyNotFoundException($"Todo with Id {request.Id} not found.");
             }

             todo.Title = request.Title;
             todo.Completed = request.Completed;
             await _db.SaveChangesAsync(cancellationToken);
        }


    }
}

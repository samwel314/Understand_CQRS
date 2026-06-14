using Learn_Cqrs.Application.Common.Interfaces;
using Learn_Cqrs.Domain.Todos;
using MediatR;

namespace Learn_Cqrs.Application.Todos.Commands.CreateTodo
{
    public sealed class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, Guid>
    {
        private readonly IAppDbContext _db;

        public CreateTodoCommandHandler(IAppDbContext db)
        {
            _db = db;
        }
        public async Task<Guid> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            var todo = new Todo
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Completed = false,
            }; 
            _db.Todos.Add(todo); 
            await _db.SaveChangesAsync(cancellationToken);
            return todo.Id; 
        }
    }
}

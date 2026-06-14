using FluentValidation;

namespace Learn_Cqrs.Application.Todos.Commands.CreateTodo
{
    public class UpdateTodoCommandValidator : AbstractValidator<UpdateTodoCommand>  
    {
        public UpdateTodoCommandValidator  ()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title is required.")
                .MaximumLength(100)
                .WithMessage("Title must not exceed 100 characters.");  
        }
    }
}

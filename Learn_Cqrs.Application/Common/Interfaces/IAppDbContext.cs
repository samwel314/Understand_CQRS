using Learn_Cqrs.Domain.Todos;
using Microsoft.EntityFrameworkCore;
namespace Learn_Cqrs.Application.Common.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Todo> Todos { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

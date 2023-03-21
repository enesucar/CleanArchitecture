using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces.Contexts
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Category> Categories { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}

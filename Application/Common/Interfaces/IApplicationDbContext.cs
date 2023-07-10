using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.Common.Interfaces;
public interface IApplicationDbContext
{
    public DbSet<Bookkeeping> Bookkeepings { get; } 
    public DbSet<Category> Category { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellation = default);

}

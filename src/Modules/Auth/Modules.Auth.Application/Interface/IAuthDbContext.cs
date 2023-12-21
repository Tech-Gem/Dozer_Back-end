using Microsoft.EntityFrameworkCore;
using Modules.Auth.Domain.Entities;

namespace Modules.Auth.Application.Interface;

public interface IAuthDbContext
{
    DbSet<User> Users { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
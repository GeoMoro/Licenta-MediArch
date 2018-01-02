using Data.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistence
{
    public interface IDatabaseContext
    {
        DbSet<UserAccount> UserAccounts { get; set; }

        int SaveChanges();
    }
}

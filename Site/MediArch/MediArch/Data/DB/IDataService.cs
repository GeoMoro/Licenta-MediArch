using MediArch.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace MediArch.Data
{
    public interface IDataService
    {
        DbSet<User> Users { get; set; }

        DbSet<Consult> Consults { get; set; }

        int SaveChanges();
    }
}

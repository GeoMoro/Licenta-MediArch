using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;
using MediArch.Models.Entity;

namespace MediArch.Data
{
    public class DataService : DbContext, IDataService
    {
        public DataService(DbContextOptions<DataService> options) : base(options)
        {
             Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Consult> Consults { get; set; }

    }

}

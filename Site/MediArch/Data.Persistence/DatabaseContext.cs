using Microsoft.EntityFrameworkCore;

namespace Data.Persistence
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        // Use entire link to entity for Scaffolding to work

        public DbSet<Data.Domain.Entities.UserAccount> UserAccounts { get; set; }

        public DbSet<Data.Domain.Entities.Consult> Consults { get; set; }

        public DbSet<Data.Domain.Entities.Medicine> Medicines { get; set; }

        //public DbSet<Data.Domain.Entities.MedicineList> MedicineLists { get; set; }
    }
}

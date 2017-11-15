using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;
using MediArch.Data;

namespace MediArch.Data
{
    public class DataService : DbContext//, IDataService
    {
        public DataService(DbContextOptions<DataService> options) : base(options)
        {
             Database.EnsureCreated();
        }

        public DbSet<Person> Persons { get; set; }

        public DbSet<MediArch.Data.Doctor> Doctor { get; set; }

        public DbSet<MediArch.Data.Pacient> Pacient { get; set; }
    }

}

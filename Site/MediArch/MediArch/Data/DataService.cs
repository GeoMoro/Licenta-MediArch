using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace MediArch.Data
{
    public class DataService : DbContext//, IDataService
    {
        public DataService(DbContextOptions<DataService> options) : base(options)
        {
             Database.EnsureCreated();
        }

        public DbSet<Person> Persons { get; set; }
    }

}

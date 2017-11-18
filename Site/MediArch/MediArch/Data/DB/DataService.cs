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

        public DbSet<Person> Persons { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Pacient> Pacients { get; set; }
        
    }

}

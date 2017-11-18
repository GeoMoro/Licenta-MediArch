using MediArch.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace MediArch.Data
{
    public interface IDataService
    {
        DbSet<User> Users { get; set; }
        
        DbSet<Person> Persons { get; set; }

        DbSet<Doctor> Doctors { get; set; }

        DbSet<Pacient> Pacients { get; set; }

        int SaveChanges();
    }
}

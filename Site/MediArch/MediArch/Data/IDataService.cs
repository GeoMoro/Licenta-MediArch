using Microsoft.EntityFrameworkCore;

namespace MediArch.Data
{
    public interface IDataService
    {
        DbSet<Person> Persons { get; set; }
        int SaveChanges();
    }
}

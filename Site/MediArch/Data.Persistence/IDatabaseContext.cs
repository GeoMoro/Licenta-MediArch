using Data.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistence
{
    public interface IDatabaseContext
    {
        DbSet<UserAccount> UserAccounts { get; set; }

        DbSet<Consult> Consults { get; set; }

        DbSet<Medicine> Medicines { get; set; }

        //DbSet<MedicineList> MedicineLists { get; set; }

        int SaveChanges();
    }
}

using Data.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Domain.Interfaces
{
    public interface IMedicineRepository
    {
        IReadOnlyList<Medicine> GetAllMedicines();
        Medicine GetMedicineById(Guid id);
        Medicine GetMedicineByName(string name);
        void Create(Medicine medicine);
        void Edit(Medicine medicine);
        void Delete(Medicine medicine);
    }
}

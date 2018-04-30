using Data.Domain.Entities;
using Data.Domain.Interfaces;
using Data.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRep
{
    public class MedicineRepository : IMedicineRepository
    {

        private readonly DatabaseContext _databaseService;

        public MedicineRepository(DatabaseContext databaseService)
        {
            _databaseService = databaseService;
        }


        public IReadOnlyList<Medicine> GetAllMedicines()
        {
            return _databaseService.Medicines.OrderBy(x => x.Name).ToList();
        }


        public Medicine GetMedicineById(Guid id)
        {
            return _databaseService.Medicines.SingleOrDefault(medicine => medicine.Id == id);
        }


        public Medicine GetMedicineByName(string name)
        {
            return _databaseService.Medicines.SingleOrDefault(medicine => medicine.Name == name);
        }


        public void Create(Medicine medicine)
        {
            _databaseService.Medicines.Add(medicine);

            _databaseService.SaveChanges();
        }


        public void Edit(Medicine medicine)
        {
            _databaseService.Medicines.Update(medicine);

            _databaseService.SaveChanges();
        }


        public void Delete(Medicine medicine)
        {
            _databaseService.Medicines.Remove(medicine);

            _databaseService.SaveChanges();
        }
        
        public bool Exists(Guid id)
        {
            return _databaseService.Medicines.Any(e => e.Id == id);
        }

        public int GetNumberOfPagesForMedicines()
        {
            int rez = 0;
            int count = GetAllMedicines().Count();
            rez = count / 5;

            if (rez * 5 < count)
            {
                rez++;
            }

            return rez;
        }

        public IReadOnlyList<Medicine> Get5MedicinesByIndex(int index)
        {
            List<Medicine> rez = new List<Medicine>() { };
            List<Medicine> allMedicines = GetAllMedicines().ToList();
            int start = (index - 1) * 5;
            int finish = start + 5;

            for (int i = start; i < finish; i++)
            {
                if (i < allMedicines.Count)
                {
                    rez.Add(allMedicines[i]);
                }
            }

            return rez;
        }
    }
}

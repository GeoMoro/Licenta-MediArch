using Data.Domain.Entities;
using Data.Domain.Interfaces;
using Data.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRep
{
    public class MedicineListRepository : IMedicineListRepository
    {
        /*
        private readonly DatabaseContext _databaseService;

        public MedicineListRepository(DatabaseContext databaseService)
        {
            _databaseService = databaseService;
        }


        public MedicineList GetMedicineListById(Guid id)
        {
            return _databaseService.MedicineLists.SingleOrDefault(medicineList => medicineList.Id == id);
        }


        public MedicineList GetMedicineListByConsultId(Guid consultId)
        {
            return _databaseService.MedicineLists.SingleOrDefault(medicineList => medicineList.ConsultId == consultId);
        }


        public void Create(MedicineList medicineList)
        {
            _databaseService.MedicineLists.Add(medicineList);

            _databaseService.SaveChanges();
        }


        public void Edit(MedicineList medicineList)
        {
            _databaseService.MedicineLists.Update(medicineList);

            _databaseService.SaveChanges();
        }


        public void Delete(MedicineList medicineList)
        {
            _databaseService.MedicineLists.Remove(medicineList);

            _databaseService.SaveChanges();
        }
        */
    }
}

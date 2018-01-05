using Data.Domain.Entities;
using Data.Domain.Interfaces;
using Data.Domain.Interfaces.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRep
{
    public class ConsultSercive : IConsultService
    {
        /*private readonly IConsultRepository _consultRepository;

        //private readonly IMedicineListRepository _medicineListRepository;

        public ConsultSercive(IConsultRepository consultRepository)//, IMedicineListRepository medicineListRepository)
        {

            _consultRepository = consultRepository;

            //_medicineListRepository = medicineListRepository;
            
        }

        public void EditConsult(Consult consult)
        {
            Guid id = consult.Id;

            _consultRepository.Edit(consult);

            //MedicineList medicineList = _medicineListRepository.GetMedicineListByConsultId(id);

            //_medicineListRepository.Edit(medicineList);

        }

        public void DeleteConsult(Consult consult)
        {
            Guid id = consult.Id;

            _consultRepository.Delete(consult);

            //MedicineList medicineList = _medicineListRepository.GetMedicineListByConsultId(id);

            //_medicineListRepository.Delete(medicineList);
        }*/
    }
}

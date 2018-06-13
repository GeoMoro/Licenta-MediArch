using Data.Domain.Entities;
using Data.Domain.Interfaces;
using Data.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRep.Repositories
{
    public class ConsultRepository : IConsultRepository
    {
        private readonly DatabaseContext _databaseService;

        public ConsultRepository(DatabaseContext databaseService)
        {
            _databaseService = databaseService;
        }
        
        public List<Consult> GetAllConsults()
        {

            List<Consult> rez = _databaseService.Consults.OrderBy(x => x.Id).ToList();

            foreach (Consult x in rez)
            {
                x.ConsultResult = x.ConsultResult.Decrypt();

                x.Medicines = x.Medicines.Decrypt();
            }

            return rez.OrderBy(x => x.ConsultDate).ToList();
        }


        public List<Consult> GetAllConsultsForGivenMedicId(Guid medicId)
        {
            List<Consult> rez = _databaseService.Consults.Where(consult => consult.MedicId == medicId).OrderBy(x => x.PacientId).ToList();

            foreach (Consult x in rez)
            {
                x.ConsultResult = x.ConsultResult.Decrypt();

                x.Medicines = x.Medicines.Decrypt();
            }

            return rez;
        }


        public List<Consult> GetAllConsultsForGivenPacientId(Guid pacientId)
        {
            List<Consult> rez = _databaseService.Consults.Where(consult => consult.PacientId == pacientId).OrderBy(x => x.MedicId).ToList();

            foreach(Consult x in rez)
            {
                x.ConsultResult = x.ConsultResult.Decrypt();

                x.Medicines = x.Medicines.Decrypt();
            }

            return rez;
        }


        public Consult GetConsultById(Guid id)
        {
            Consult rez = _databaseService.Consults.SingleOrDefault(consult => consult.Id == id);

            rez.ConsultResult = rez.ConsultResult.Decrypt();

            rez.Medicines = rez.Medicines.Decrypt();

            return rez;
        }
        

        public void Create(Consult consult)
        {
            consult.ConsultResult=consult.ConsultResult.Encrypt();

            consult.Medicines=consult.Medicines.Encrypt();


            _databaseService.Consults.Add(consult);

            _databaseService.SaveChanges();
        }


        public void Edit(Consult consult)
        {
            consult.ConsultResult=consult.ConsultResult.Encrypt();

            consult.Medicines=consult.Medicines.Encrypt();

            _databaseService.Consults.Update(consult);

            _databaseService.SaveChanges();
        }


        public void Delete(Consult consult)
        {
            _databaseService.Consults.Remove(consult);

            _databaseService.SaveChanges();
        }

        public bool Exists(Guid id)
        {
            return _databaseService.Consults.Any(e => e.Id == id);
        }

        public int GetNumberOfConsults()
        {
            return _databaseService.Consults.Count();
        }

        public int GetNumberOfConsultsForMedic(Guid medicId)
        {
            return _databaseService.Consults.Where(consult => consult.MedicId == medicId).Count();
        }

        public int GetNumberOfConsultsForPacient(Guid pacientId)
        {
            return _databaseService.Consults.Where(consult => consult.PacientId == pacientId).Count();
        }
    }
}

using Data.Domain.Entities;
using Data.Domain.Interfaces;
using Data.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRep
{
    public class ConsultRepository : IConsultRepository
    {
        private readonly DatabaseContext _databaseService;

        public ConsultRepository(DatabaseContext databaseService)
        {
            _databaseService = databaseService;
        }


        public IReadOnlyList<Consult> GetAll()
        {
            return _databaseService.Consults.ToList();
        }


        public IReadOnlyList<Consult> GetAllConsultsForGivenMedicId(Guid medicId)
        {
            return _databaseService.Consults.Where(consult => consult.MedicId == medicId).ToList();
        }


        public IReadOnlyList<Consult> GetAllConsultsForGivenPacientId(Guid pacientId)
        {
            return _databaseService.Consults.Where(consult => consult.PacientId == pacientId).ToList();
        }


        public Consult GetConsultById(Guid id)
        {
            return _databaseService.Consults.SingleOrDefault(consult => consult.Id == id);
        }
        

        public void Create(Consult consult)
        {
            _databaseService.Consults.Add(consult);

            _databaseService.SaveChanges();
        }


        public void Edit(Consult consult)
        {
            _databaseService.Consults.Update(consult);

            _databaseService.SaveChanges();
        }


        public void Delete(Consult consult)
        {
            _databaseService.Consults.Remove(consult);

            _databaseService.SaveChanges();
        }

    }
}

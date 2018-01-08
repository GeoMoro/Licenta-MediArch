using Data.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Domain.Interfaces
{
    public interface IConsultRepository
    {
        IReadOnlyList<Consult> GetAll();
        IReadOnlyList<Consult> GetAllConsultsForGivenMedicId(Guid medicId);
        IReadOnlyList<Consult> GetAllConsultsForGivenPacientId(Guid pacientId);
        Consult GetConsultById(Guid id);
        void Create(Consult consult);
        void Edit(Consult consult);
        void Delete(Consult consult);
        bool Exists(Guid id);
    }
}

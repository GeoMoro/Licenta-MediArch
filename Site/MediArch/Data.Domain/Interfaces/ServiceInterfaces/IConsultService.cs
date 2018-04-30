using Data.Domain.Entities;
using Data.Domain.Interfaces.ServiceInterfaces.Models.ConsultViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain.Interfaces.ServiceInterfaces
{
    public interface IConsultService
    {
        IReadOnlyList<Consult> GetAll();
        IReadOnlyList<Consult> GetAllConsultsForGivenMedicId(Guid medicId);
        IReadOnlyList<Consult> GetAllConsultsForGivenPacientId(Guid pacientId);
        Consult GetConsultById(Guid id);
        Task Create(ConsultCreateModel consultCreateModel);
        Task Edit(ConsultEditModel consultEditModel);
        void Delete(Consult consult);
        bool Exists(Guid id);
        List<string> GetNamesOfFiles(Guid id);
        Stream SearchConsultFile(Guid consultId, string fileName);
        void DeleteFile(string fileName, Guid consultId);
        void DeleteFilesForGivenId(Guid id);
        string getThisFileLocation(Guid id);

        int GetNumberOfPagesForConsults();
        IReadOnlyList<Consult> Get5ConsultsByIndex(int index);

        int GetNumberOfPagesForMyConsultsById(Guid medicId);
        IReadOnlyList<Consult> Get5ConsultsForDoctorByIndex(Guid medicId,int index);
        int GetNumberOfPagesForMyResultsById(Guid pacientId);
        IReadOnlyList<Consult> Get5ConsultsForPacientByIndex(Guid pacientId, int index);

    }
}

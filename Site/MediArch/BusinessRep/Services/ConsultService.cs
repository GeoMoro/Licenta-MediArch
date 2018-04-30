using Data.Domain.Interfaces.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Data.Domain.Entities;
using Data.Persistence;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using Data.Domain.Interfaces;
using System.IO;
using Data.Domain.Interfaces.ServiceInterfaces.Models.ConsultViewModels;
using System.Threading.Tasks;

namespace BusinessRep.Services
{
    public class ConsultService : IConsultService
    {
        private readonly IConsultRepository _repository;

        private readonly IHostingEnvironment _env;

        public ConsultService(IConsultRepository repository, IHostingEnvironment env)
        {
            _repository = repository;
            _env = env;
        }
        
        public IReadOnlyList<Consult> GetAll()
        {
            return _repository.GetAll().OrderBy(x=>x.ConsultDate).ToList();
        }


        public IReadOnlyList<Consult> GetAllConsultsForGivenMedicId(Guid medicId)
        {
            return _repository.GetAllConsultsForGivenMedicId(medicId).OrderBy(x => x.ConsultDate).ToList();
        }


        public IReadOnlyList<Consult> GetAllConsultsForGivenPacientId(Guid pacientId)
        {
            return _repository.GetAllConsultsForGivenPacientId(pacientId).OrderBy(x => x.ConsultDate).ToList();
        }


        public Consult GetConsultById(Guid id)
        {
            return _repository.GetConsultById(id);
        }
        

        public async Task Edit(ConsultEditModel consultEditModel)
        {
            Consult consult = new Consult()
            {
                Id = consultEditModel.Id,
                MedicId = consultEditModel.MedicId,
                PacientId = consultEditModel.PacientId,
                ConsultDate = consultEditModel.ConsultDate,
                Medicines = consultEditModel.Medicines,
                ConsultResult = consultEditModel.ConsultResult
            };

            _repository.Edit(consult);

            if (consultEditModel.File != null)
            {
                foreach (var file in consultEditModel.File)
                {
                    if (file.Length > 0)
                    {
                        var path = Path.Combine(_env.WebRootPath, "Consults/" + consult.Id);

                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        
                        using (var fileStream = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                        }
                    }
                }
            }
        }


        public void Delete(Consult consult)
        {
            DeleteFilesForGivenId(consult.Id);

            _repository.Delete(consult);
        }


        public bool Exists(Guid id)
        {
            return _repository.Exists(id);
        }
        
        public async Task Create(ConsultCreateModel consultCreateModel)
        {
            Consult consult = new Consult() {
                Id = new Guid(),
                MedicId= consultCreateModel.MedicId,
                PacientId = consultCreateModel.PacientId,
                ConsultDate = DateTime.Now,
                Medicines= consultCreateModel.Medicines,
                ConsultResult= consultCreateModel.ConsultResult
            };

            _repository.Create(consult);

            if (consultCreateModel.File != null)
            {
                foreach (var file in consultCreateModel.File)
                {
                    if (file.Length > 0)
                    {
                        string path = Path.Combine(_env.WebRootPath, "Consults\\" + consult.Id);

                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        
                        using (var fileStream = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                        }
                    }
                }
            }

        }
        
        public List<string> GetNamesOfFiles(Guid id)
        {
            List<string> fileList = new List<string>();
            string path = Directory.GetCurrentDirectory() + "\\wwwroot\\Consults\\" + id;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (var files in Directory.GetFiles(path))
            {
                fileList.Add(Path.GetFileName(files));
            }

            return fileList;
        }
        
        public void DeleteFilesForGivenId(Guid id)
        {

            var searchedPath = Path.Combine(_env.WebRootPath, "Consults/" + id);
            if (Directory.Exists(searchedPath))
            {
                Directory.Delete(searchedPath, true);
            }
            
        }

        public Stream SearchConsultFile(Guid consultId, string fileName)
        {
            var searchedPath = Path.Combine(_env.WebRootPath, "Consults/" + consultId + "/" + fileName);
            Stream file = new FileStream(searchedPath, FileMode.Open);

            return file;
        }

        public void DeleteFile(string fileName, Guid consultId)
        {
            var searchedPath = Path.Combine(_env.WebRootPath, "Consults/" + consultId + "/" + fileName);

            if (File.Exists(searchedPath))
            {
                File.Delete(searchedPath);
            }
        }

        public string getThisFileLocation(Guid id)
        {
            return _env.WebRootPath + "Consults/Delete" + id;
        }

        public int GetNumberOfPagesForConsults()
        {
            int rez = 0;
            int count = GetAll().Count();
            rez = count / 5;

            if (rez * 5 < count)
            {
                rez++;
            }

            return rez;
        }

        public IReadOnlyList<Consult> Get5ConsultsByIndex(int index)
        {
            List<Consult> rez = new List<Consult>() { };
            List<Consult> allConsults = GetAll().ToList();
            int start = (index - 1) * 5;
            int finish = start + 5;

            for (int i = start; i < finish; i++)
            {
                if (i < allConsults.Count)
                {
                    rez.Add(allConsults[i]);
                }
            }

            return rez;
        }

        public int GetNumberOfPagesForMyConsultsById(Guid medicId)
        {
            int rez = 0;
            int count = GetAllConsultsForGivenMedicId(medicId).Count();
            rez = count / 5;

            if (rez * 5 < count)
            {
                rez++;
            }

            return rez;
        }

        public IReadOnlyList<Consult> Get5ConsultsForDoctorByIndex(Guid medicId, int index)
        {
            List<Consult> rez = new List<Consult>() { };
            List<Consult> allConsults = GetAllConsultsForGivenMedicId(medicId).ToList();
            int start = (index - 1) * 5;
            int finish = start + 5;

            for (int i = start; i < finish; i++)
            {
                if (i < allConsults.Count)
                {
                    rez.Add(allConsults[i]);
                }
            }

            return rez;
        }

        public int GetNumberOfPagesForMyResultsById(Guid pacientId)
        {
            int rez = 0;
            int count = GetAllConsultsForGivenPacientId(pacientId).Count();
            rez = count / 5;

            if (rez * 5 < count)
            {
                rez++;
            }

            return rez;
        }

        public IReadOnlyList<Consult> Get5ConsultsForPacientByIndex(Guid pacientId, int index)
        {
            List<Consult> rez = new List<Consult>() { };
            List<Consult> allConsults = GetAllConsultsForGivenPacientId(pacientId).ToList();
            int start = (index - 1) * 5;
            int finish = start + 5;

            for (int i = start; i < finish; i++)
            {
                if (i < allConsults.Count)
                {
                    rez.Add(allConsults[i]);
                }
            }

            return rez;
        }
    }
}

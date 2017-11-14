using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MediArch.DTOs;
using MediArch.Models;

namespace MediArch.Controllers.API
{
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        // GET: Person
        private DatabaseContext _repository;

        public PersonController()
        {
            _repository = new DatabaseContext();
        }

        // GET /api/persons
        public IEnumerable<Person> GetAllPersons()
        {
            return _repository.Persons;
        }

        // GET /api/persons/id
        public Person GetPerson(Guid id)
        {
            return _repository.Persons.FirstOrDefault(p => p.Id == id);
            //.Where(p => p.Id == id);
        }

        // POST /api/persons
        [HttpPost]
        public void CreatePerson(Person person)
        {
            _repository.Persons.Add(person);
            _repository.SaveChanges();
        }

        // PUT /api/persons/id
        [HttpPut]
        public void UpdatePerson(Guid id, PersonDTO person)
        {
        //    var pers = GetPerson(id);
            
        //    _repository.Persons.Update(pers,person);
        //    _repository.SaveChanges();
        }

        // DELETE /api/persons/1
        [HttpDelete]
        public void DeletePerson(Guid id)
        {
            var pers = GetPerson(id);
            _repository.Persons.Remove(pers);
            _repository.SaveChanges();

        }
    }
}
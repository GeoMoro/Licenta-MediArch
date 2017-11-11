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
        public Person GetPerson(int id)
        {
            return null;
        }

        // POST /api/persons
        [HttpPost]
        public void CreatePerson(PersonDTO personDTO)
        {
           
        }

        // PUT /api/persons/id
        [HttpPut]
        public void UpdatePerson(int id, PersonDTO personDTO)
        {
           
        }

        // DELETE /api/persons/1
        [HttpDelete]
        public void DeletePerson(int id)
        {
            
        }
    }
}
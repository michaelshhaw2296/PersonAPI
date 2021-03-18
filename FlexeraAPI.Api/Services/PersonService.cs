using FlexeraAPI.Api.Models;
using FlexeraAPI.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlexeraAPI.Api.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public IEnumerable<Person> GetAllPeople()
        {
            return _personRepository.GetAll().OrderBy(c => c.FirstName);
        }

        public Person GetPersonById(int personId)
        {
            return _personRepository.Get(personId);
        }

        public Person AddPerson(Person person)
        {
            return _personRepository.Add(person);
        }

        public void DeletePerson(int personId)
        {
            _personRepository.Delete(personId);
        }

        public Person UpdatePerson(Person person)
        {
            return _personRepository.Update(person);
        }
    }
}

using FlexeraAPI.Api.Helper;
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
        // The IPersonRepository which executes call to the datastore
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        // <summary>
        // Returns a list of all people in the datastore from repository
        // </summary>
        // param name="peopleParameters"> Parameters supplied in the request query string to allow people results to be filtered
        // <returns>
        // Returns PageList object of all people
        // </returns>
        public PageList<Person> GetAllPeople(PeopleParameters peopleParameters)
        {
            return PageList<Person>.ToPagedList(_personRepository.GetAll(),
                peopleParameters.PageNumber, peopleParameters.PageSize);
        }

        // <summary>
        // Calls to the repository to get single person based on person id
        // </summary>
        // param name="personId"> the persons id
        // <returns>
        // Returns single person object
        // </returns>
        public Person GetPersonById(int personId)
        {
            return _personRepository.Get(personId);
        }

        // <summary>
        // Calls to the repository to create a new person
        // </summary>
        // param name="person"> person object that is being created
        // <returns>
        // Returns newly created person object
        // </returns>
        public Person AddPerson(Person person)
        {
            return _personRepository.Add(person);
        }

        // <summary>
        // Calls to the repository to delete a person
        // </summary>
        // param name="personId"> person Id that is being deleted
        public void DeletePerson(int personId)
        {
            _personRepository.Delete(personId);
        }

        // <summary>
        // Calls to the repository to update an existing person
        // </summary>
        // param name="person"> person object that is being updated
        // <returns>
        // Returns updated person object
        // </returns>
        public Person UpdatePerson(Person person)
        {
            return _personRepository.Update(person);
        }
    }
}

using FlexeraAPI.Api.Helper;
using FlexeraAPI.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlexeraAPI.Api.Models
{
    public class PersonRepository : IPersonRepository
    {
        // The datastore for our people - currently using in memory datastore but can be easily switched out within start up class
        private readonly AppDbContext _appDbContext;

        public PersonRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // <summary>
        // Calls to the datastore to return all people
        // </summary>
        // <returns>
        // Returns queryable list of all people
        // </returns>
        public IQueryable<Person> GetAll()
        {
            return _appDbContext.People;
        }

        // <summary>
        // Calls to the datastore to return specific person based on person id
        // </summary>
        // param name="personId"> person id
        // <returns>
        // Returns single person object
        // </returns>
        public Person Get(int personId)
        {
            return _appDbContext.People.FirstOrDefault(p => p.PersonId == personId);
        }

        // <summary>
        // Calls to the datastore to return create a new person
        // </summary>
        // param name="person"> person object that is being created
        // <returns>
        // Returns newly created person object
        // </returns>
        public Person Add(Person person)
        {
            var newPerson = _appDbContext.People.Add(person);

            _appDbContext.SaveChanges();

            return newPerson.Entity;
        }

        // <summary>
        // Calls to the datastore to delete person from datastore
        // </summary>
        // param name="person"> person object that is being deleted
        public void Delete(int personId)
        {
            var person = _appDbContext.People.FirstOrDefault(p => p.PersonId == personId);

            if (person == null) return;

            _appDbContext.People.Remove(person);
            _appDbContext.SaveChanges();
        }

        // <summary>
        // Calls to the datastore to update an existing person object
        // </summary>
        // param name="person"> person object that is being updated
        // <returns>
        // Returns newly updated person object
        // </returns>
        public Person Update(Person person)
        {
            var existingPerson = _appDbContext.People.FirstOrDefault(p => p.PersonId == person.PersonId);

            if (existingPerson != null)
            {
                existingPerson.FirstName = person.FirstName;
                existingPerson.LastName = person.LastName;
                existingPerson.Address = person.Address;
                existingPerson.Age = person.Age;
                existingPerson.Email = person.Email;

                _appDbContext.SaveChanges();

                return existingPerson;
            }

            return null;           
        }
    }
}

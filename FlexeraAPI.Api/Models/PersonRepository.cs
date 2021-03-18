using FlexeraAPI.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlexeraAPI.Api.Models
{
    public class PersonRepository : IPersonRepository
    {

        private readonly AppDbContext _appDbContext;

        public PersonRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        
        public IEnumerable<Person> GetAll()
        {
            return _appDbContext.People;
        }

        public Person Get(int personId)
        {
            return _appDbContext.People.FirstOrDefault(p => p.PersonId == personId);
        }

        public Person Add(Person person)
        {
            var newPerson = _appDbContext.People.Add(person);

            _appDbContext.SaveChanges();

            return newPerson.Entity;
        }

        public void Delete(int personId)
        {
            var person = _appDbContext.People.FirstOrDefault(p => p.PersonId == personId);

            if (person == null) return;

            _appDbContext.People.Remove(person);
            _appDbContext.SaveChanges();
        }

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

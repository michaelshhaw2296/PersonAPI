using FlexeraAPI.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlexeraAPI.Api.Models
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAll();

        Person Get(int personId);

        Person Add(Person person);

        void Delete(int personId);


        // Additional Endpoint
        Person Update(Person person);
    }
}

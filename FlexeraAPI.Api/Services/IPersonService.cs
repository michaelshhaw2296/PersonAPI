using FlexeraAPI.Api.Helper;
using FlexeraAPI.Api.Models;
using FlexeraAPI.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlexeraAPI.Api.Services
{
    public interface IPersonService
    {
        PageList<Person> GetAllPeople(PeopleParameters peopleParameters);

        Person GetPersonById(int personId);

        Person AddPerson(Person person);

        void DeletePerson(int personId);

        Person UpdatePerson(Person person);
    }
}

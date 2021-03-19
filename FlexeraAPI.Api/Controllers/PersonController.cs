using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlexeraAPI.Shared;
using FlexeraAPI.Api.Models;
using FlexeraAPI.Api.Services;
using Newtonsoft.Json;

namespace FlexeraAPI.Api.Controllers
{
    [Route("app/people/")]
    [ApiController]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        // <summary>
        // Returns a list of all people in the datastore
        // </summary>
        // param name="peopleParams"> User issued params that set up the pagination ability
        // <returns>
        // Command that returns all the stored people
        // </returns>
        [HttpGet]
        public IActionResult GetAllPeople([FromQuery] PeopleParameters peopleParams)
        {
            var allPeople = _personService.GetAllPeople(peopleParams);

            var metadata = new
            {
                allPeople.TotalCount,
                allPeople.PageSize,
                allPeople.CurrentPage,
                allPeople.HasNext,
                allPeople.HasPrevious
            };

            // Can be used from a front end UI to set up pagination
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(allPeople);
        }

        // <summary>
        // Returns a single person based on person id
        // </summary>
        // param name="personId"> The persons id
        // <returns>
        // Command that returns single person 
        // </returns>
        [HttpGet("{personId}")]
        public IActionResult GetPersonById(int personId)
        {
            return Ok(_personService.GetPersonById(personId));
        }

        // <summary>
        // Command which gives the user the ability to create a new person and store in the datastore
        // </summary>
        // param name="person"> The persons object based of the request body
        // <returns>
        // Command that creates and returns a new person 
        // </returns>
        [HttpPost]
        public IActionResult AddPerson([FromBody] Person person)
        {
            if (person == null) return BadRequest();

            var newPerson = _personService.AddPerson(person);

            return Created("person", newPerson);
         }

        // <summary>
        // Command which gives the user the ability to delete a person from the datastore
        // </summary>
        // param name="personId"> The person id which is used to do the removal
        // <returns>
        // Returns NoContent response when the person is successfully deleted 
        // </returns>
        [HttpDelete("{personId}")]
        public IActionResult DeletePerson(int personId)
        {
            if (personId == 0)
            {
                return BadRequest();
            }

            var personToDelete = _personService.GetPersonById(personId);

            if (personToDelete == null)
            {
                return NotFound();
            }

            _personService.DeletePerson(personId);

            // This is on successful delete
            return NoContent();
        }


        // <summary>
        // Command which gives the user the ability to update a person
        // </summary>
        // param name="person"> The person in which is being updated
        // <returns>
        // Returns NoContent response when the person is successfully updated 
        // </returns>
        [HttpPut]
        public IActionResult UpdatePerson([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }

            var personToUpdate = _personService.GetPersonById(person.PersonId);

            if (personToUpdate == null)
            {
                return NotFound();
            }

            _personService.UpdatePerson(person);

            // This is on successful update
            return NoContent();
        }
    }
}

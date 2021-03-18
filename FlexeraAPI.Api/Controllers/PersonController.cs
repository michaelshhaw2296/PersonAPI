using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlexeraAPI.Shared;
using FlexeraAPI.Api.Models;
using FlexeraAPI.Api.Services;

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

        [HttpGet]
        public IActionResult GetAllPeople()
        {
            return Ok(_personService.GetAllPeople());
        }

        [HttpGet("{id}")]
        public IActionResult GetPersonById(int personId)
        {
            return Ok(_personService.GetPersonById(personId));
        }

        [HttpPost]
        public IActionResult AddPerson([FromBody] Person person)
        {
            if (person == null) return BadRequest();

            var newPerson = _personService.AddPerson(person);

            return Created("person", newPerson);
         }

        [HttpDelete("{id}")]
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleWebApi.Data;
using SimpleWebApi.Data.Service;

namespace SImpleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private PersonService personService;
        public PersonController()
        {
            personService = new PersonService();
        }

        [HttpGet]
        public  async Task<ActionResult<Person>> GetPeople()
        {
            var people = personService.GetAll();

            if (people == null)
                return NotFound();

            return Ok(people);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = personService.GetById(id);

            if (person == null)
                return NotFound();

            return Ok(person);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            if (personService.Delete(id))
            {
                return Ok($"Deleted person with id - {id}");
            }
            return BadRequest("Can't delete person with this index!");
        }
        [HttpPost]
        public async Task<IActionResult> AddPerson([FromBody] Person person)
        {
            if (personService.Add(person))
            {
                return Created("Successfully created",person);
            }
            return BadRequest("Can't create new person");
        }


    }
}
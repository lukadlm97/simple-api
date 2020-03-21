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
    public class HobbyController : ControllerBase
    {
        PersonService personService;
        public HobbyController()
        {
            personService = new PersonService();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHobby(int id,[FromBody] Person person)
        {
            if (personService.UpdateHobby(id, person))
            {
                return Ok("Object has been successfully updated.");
            }
            return BadRequest("Bad Request!");
        }
    }
}
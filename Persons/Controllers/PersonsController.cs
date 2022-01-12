using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persons.DTOs;
using Persons.Services;

namespace Persons.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        public PersonsService PersonsService { get; }

        public PersonsController(PersonsService personsService)
        {
            PersonsService = personsService;
        }

        [HttpGet]
        public IActionResult GetPersons()
        {
            return Ok(PersonsService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetPerson(int id)
        {
            return Ok(PersonsService.GetSingle(id));
        }

        [HttpPost]
        public IActionResult AddPerson([FromBody] PersonDTO input)
        {
            var person = PersonsService.AddSingle(input);

            if (person == null) return BadRequest();

            return Ok(PersonResponseDTO.From(person));
        }
    }
}

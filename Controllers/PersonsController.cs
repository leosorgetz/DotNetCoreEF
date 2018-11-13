using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTesteDotNet.Business;
using ApiTesteDotNet.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiTesteDotNet.Controllers
{   

    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private IPersonBusiness _personBusiness;

        public PersonsController(IPersonBusiness personBusiness) => _personBusiness = personBusiness;

        // GET api/person
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }

        // GET api/person/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {   
            var person  = _personBusiness.FindById(id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        // POST api/person
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }

            return new ObjectResult(_personBusiness.Create(person));
        }

        // PUT api/person
        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }
            
            var _person  = _personBusiness.FindById(person.Id);
            
            if (_person == null){
                return NotFound();
            }
           
            return new ObjectResult(_personBusiness.Update(person));
        }

        // DELETE api/person/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personBusiness.Delete(id);
            return NoContent();
        }
    }
}

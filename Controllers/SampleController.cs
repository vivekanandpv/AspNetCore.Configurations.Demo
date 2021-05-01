using AspNetCore.Configurations.Demo.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.Configurations.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly Person _person;

        //  IConfiguration itself can be injected, but we don't prefer to work with large configuration
        public SampleController(IOptions<Person> options, IConfiguration config)
        {
            _person = options.Value;    //  preferred approach, cleaner approach

            Person p = config.GetSection("Person").Get<Person>();   //  archaic, old approach
        }

        public IActionResult Get()
        {
            return Ok(_person.FirstName);
        }
    }
}

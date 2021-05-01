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
        private readonly List<Person> _persons;

        public SampleController(IOptions<List<Person>> options)
        {
            _persons = options.Value;   //  Is it worth the complexity?
            _persons.Add(new Person());
        }

        public IActionResult Get()
        {
            return Ok(_persons.Count());
        }
    }
}

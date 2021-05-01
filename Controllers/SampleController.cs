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
        private readonly IEnumerable<Person> _persons;

        public SampleController(IEnumerable<Person> persons)
        {
            _persons = persons;
        }



        //public SampleController(IConfiguration config)
        //{
        //    _persons = config.GetSection("Persons").Get<IEnumerable<Person>>();
        //}

        public IActionResult Get()
        {
            return Ok(_persons.Count());
        }
    }
}

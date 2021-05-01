using AspNetCore.Configurations.Demo.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCore.Configurations.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private Person _person;

        //  IOptionsSnapshot<T> is scoped for DI
        public SampleController(IOptionsSnapshot<Person> options)
        {
            _person = options.Value;
        }



        //public SampleController(IConfiguration config)
        //{
        //    _persons = config.GetSection("Persons").Get<IEnumerable<Person>>();
        //}

        public IActionResult Get()
        {
            return Ok(_person.FirstName);
        }
    }
}

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

        public SampleController(IOptionsMonitor<Person> options)
        {
            //  ok for most cases
            _person = options.CurrentValue;

            //  just in case the value changes between injection and use in get or another method
            options.OnChange(p =>
            {
                if (!string.IsNullOrEmpty(p.FirstName) && p.FirstName.Length > 10)
                {
                    this._person = p;
                }
                else
                {
                    _person = new Person { FirstName = "Default FirstName", LastName = "Default LastName", City = "Default City" };
                }
            });
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.Configurations.Demo.Domain
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public Contact Contact { get; set; }
    }

    public class Contact
    {
        public long MobileNumber { get; set; }
    }
}

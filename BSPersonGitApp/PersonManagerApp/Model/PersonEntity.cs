using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonManagerApp.Model
{
    public class PersonEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Title { get; set; }

        public int Age { get; set; }

        public string City { get; set; }

        public string PostCode { get; set; }
    }
}

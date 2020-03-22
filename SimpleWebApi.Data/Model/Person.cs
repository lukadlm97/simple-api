using SimpleWebApi.Data.Model;
using System;
using System.Collections.Generic;

namespace SimpleWebApi.Data
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public bool IsHeMarryed { get; set; }
        public List<Hobby>  Hobbies { get; set; }
    }
}

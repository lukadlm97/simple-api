using SimpleWebApi.Data.Model;
using System;

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
        public Hobby Hobby { get; set; }
    }
}

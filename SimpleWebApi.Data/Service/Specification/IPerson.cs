using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleWebApi.Data.Service.Specification
{
    interface IPerson
    {
        IEnumerable<Person> GetAll();
        Person GetById(int id);
        bool Update(int id, Person person);
        bool Delete(int id);
        bool Add(Person person);
        bool UpdateHobby(int id, Person person);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleWebApi.Data.Repository
{
    class MemoryRepository
    {
        public List<Person> People { get; set; }
        public MemoryRepository()
        {
            People = new List<Person>
            {
                new Person
                {
                    Id = 1,
                    FirstName = "Luka",
                    LastName = "Radovanovic",
                    Age = 22,
                    Country = "Serbia",
                    IsHeMarryed = false
                },
                new Person
                {
                    Id = 2,
                    FirstName = "Nikola",
                    LastName = "Zigic",
                    Age = 39,
                    Country = "Serbia",
                    IsHeMarryed = true
                },
                new Person
                {
                    Id = 3,
                    FirstName = "Luka",
                    LastName = "Jovic",
                    Age = 23,
                    Country = "Serbia",
                    IsHeMarryed = false
                },
            };
        }

        public List<Person> GetPeople()
        {
            return People;
        }

        public bool AddPerson(Person person)
        {
            try
            {
                People.Add(person);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
            
        public Person GetPersonById(int id)
        {
            foreach (Person p in People)
            {
                if (p.Id == id)
                    return p;
            }

            return null;
        }

        public bool DeletePerson(int id)
        {
            Person person = GetPersonById(id);

            if (person ==  null)
                return false;

            People.Remove(person);

            return true;
        }

        public bool UpdatePerson(int id,Person person)
        {
            Person personForUpdate = GetPersonById(id);
            if(personForUpdate == null)
            {
                return AddPerson(person);
            }
            personForUpdate = person;
            
            return true;
        }

    }
}

using SimpleWebApi.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleWebApi.Data.Repository
{
    class MemoryRepository
    {
        private static MemoryRepository _instance;
        public List<Person> People { get; set; }

        public static MemoryRepository Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new MemoryRepository();
                }
                return _instance;
            }
        }

        private MemoryRepository()
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
                    IsHeMarryed = false,
                    Hobby = new Hobby()
                    {
                        Id=1,
                        Name="Running"
                    }
                },
                new Person
                {
                    Id = 2,
                    FirstName = "Nikola",
                    LastName = "Zigic",
                    Age = 39,
                    Country = "Serbia",
                    IsHeMarryed = true,
                    Hobby = new Hobby()
                    {
                        Id=2,
                        Name="Music"
                    }
                },
                new Person
                {
                    Id = 3,
                    FirstName = "Luka",
                    LastName = "Jovic",
                    Age = 23,
                    Country = "Serbia",
                    IsHeMarryed = false,
                    Hobby = new Hobby()
                    {
                        Id=3,
                        Name="Reading"
                    }
                },
            };
        }

        internal bool UpdateHobby(int id, Person person)
        {
            Person personForUpdate = GetPersonById(id);
            if(personForUpdate == null)
            {
                return false;
            }

            SetHobbyAttributes(personForUpdate, person.Hobby);

            return true;
        }

        private void SetHobbyAttributes(Person personForUpdate, Hobby hobby)
        {
            personForUpdate.Hobby.Id = hobby.Id;
            personForUpdate.Hobby.Name = hobby.Name;
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

            SetAttributes(personForUpdate, person);
           
            return true;
        }

        private void SetAttributes(Person personForUpdate, Person person)
        {
            personForUpdate.Id = person.Id;
            personForUpdate.FirstName = person.FirstName;
            personForUpdate.LastName = person.LastName;
            personForUpdate.Country = person.Country;
            personForUpdate.Age = person.Age;
            personForUpdate.IsHeMarryed = person.IsHeMarryed;
        }
    }
}

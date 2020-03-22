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
                     Hobbies = new List<Hobby>
                    {
                           new Hobby
                           {
                               Id = 5,
                               Name ="Running"
                           },
                           new Hobby
                           {
                               Id=6,
                               Name="Reading"
                           }
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
                     Hobbies = new List<Hobby>
                    {
                           new Hobby
                           {
                               Id = 3,
                               Name = "Reading"
                           },
                           new Hobby
                           {
                               Id = 4,
                               Name = "Biliars"
                           }
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
                    Hobbies = new List<Hobby>
                    {
                           new Hobby
                           {
                               Id = 1,
                               Name ="Basketball"
                           },
                           new Hobby
                           {
                               Id = 2,
                               Name = "Swimming"
                           }
                    }
                },
            };
        }
        
        internal int GetMaxHobbyId()
        {
            int id = -1;

            FoundHobbyId(ref id);  

            if (id == -1)
                return 1;

            return id;
        }

        private void FoundHobbyId(ref int id)
        {
            foreach (Person person in People)
            {
                if (person.Hobbies == null)
                {
                    continue;
                }
                foreach (Hobby hobby in person.Hobbies)
                {
                    if (hobby.Id > id)
                        id = hobby.Id;
                }
            }
        }

        public int GetMaxIdPeople()
        {
            int id = -1;
            if (People == null)
                return 1;
            FoundId(ref id);
            if (id == -1)
                return 1;
            return id;
        }

        public void FoundId(ref int id)
        {
            foreach (Person person in People)
            {
                if (person.Id > id)
                    id = person.Id;
            }
        }

        public bool AddNewHobby(int id,Hobby hobby)
        {
            Person person = GetPersonById(id);

            if(person == null)
            {
                return false;
            }

            person.Hobbies.Add(hobby);

            return true;
        }


        internal bool UpdateHobby(int id, Person person)
        {
            Person personForUpdate = GetPersonById(id);

            if(personForUpdate == null)
            {
                return false;
            }

            foreach(Hobby hobby in personForUpdate.Hobbies)
            {
                SetHobbyAttributes(person, hobby);
            }

            return true;
        }

        private void SetHobbyAttributes(Person person, Hobby hobby)
        {
            foreach(Hobby hobbyForUpdate in person.Hobbies)
            {
                if(hobbyForUpdate.Id == hobby.Id)
                {
                    hobby.Name = hobbyForUpdate.Name;
                }
            }
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

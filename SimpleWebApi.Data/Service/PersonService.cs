using SimpleWebApi.Data.Model;
using SimpleWebApi.Data.Repository;
using SimpleWebApi.Data.Service.Specification;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleWebApi.Data.Service
{
    public class PersonService : IPerson
    {
        private MemoryRepository memoryRepository = MemoryRepository.Instance;
        public PersonService()
        {
            
        }
        public bool Add(Person person)
        {
            person.Id = GetMaxPersonId();
            return memoryRepository.AddPerson(person);
        }

        private int GetMaxPersonId()
        {
            return memoryRepository.GetMaxIdPeople()+1;
        }

        public bool Delete(int id)
        {
            return memoryRepository.DeletePerson(id);
        }

        public IEnumerable<Person> GetAll()
        {
            return memoryRepository.GetPeople();
        }

        public Person GetById(int id)
        {
            return memoryRepository.GetPersonById(id);
        }

        public bool Update(int id, Person person)
        {
            return memoryRepository.UpdatePerson(id, person);
        }

        public bool UpdateHobby(int id, Person person)
        {
            return memoryRepository.UpdateHobby(id, person);
        }

        public bool AddNewHobby(int id,Hobby hobby)
        {
            hobby.Id = GetMaxHobbyId();
            return memoryRepository.AddNewHobby(id, hobby);
        }

        private int GetMaxHobbyId()
        {
            return memoryRepository.GetMaxHobbyId()+1;
        }
    }
}

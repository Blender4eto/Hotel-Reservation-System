using Hotel_Reservation_System.Application;
using Hotel_Reservation_System.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_System.Infrastructure
{
    public class FilePersonRepository : IPersonRepository
    {
        public FileStorage storage;
        public FilePersonRepository(FileStorage storage)
        {
            this.storage = storage;
        }
        public IReadOnlyList<Person> GetPeople()
        {
            var db = storage.Load();
            return db.Persons;
        }
        public Person GetPersonById(int personid)
        {
            var db = storage.Load();
            foreach (var person in db.Persons)
            {
                if (person.Id == id)
                {
                    return person;
                }
            }
            throw new Exception("Person not found");
        }
    }
}

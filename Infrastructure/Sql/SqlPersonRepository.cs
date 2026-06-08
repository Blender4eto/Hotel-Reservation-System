using Hotel_Reservation_System.Application.Interfaces;
using Hotel_Reservation_System.Domain.Entities;
using Hotel_Reservation_System.Infrastructure.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_System.Infrastructure.Sql
{
    public class SqlPersonRepository : IPersonRepository
    {
        AppDbContext db;

        public SqlPersonRepository(AppDbContext db)
        {
            this.db = db;
        }
        public IReadOnlyList<Person> GetPeople()
        {
            return db.People.ToList();
        }
        public Person GetPersonById(int personid)
        {
            foreach (var person in db.People)
            {
                if (person.Id == personid)
                {
                    return person;
                }
            }
            throw new Exception("Person not found");
        }
        public void AddPerson(Person person)
        {
            db.People.Add(person);
            db.SaveChanges();
        }
    }
}

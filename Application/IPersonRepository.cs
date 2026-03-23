using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Reservation_System.Domain.Entities;

namespace Hotel_Reservation_System.Application
{
    public interface IPersonRepository
    {
        IReadOnlyList<Person> GetPeople();
        Person GetPersonById(int personId);
        void AddPerson(Person person);
    }
}

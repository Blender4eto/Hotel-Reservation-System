using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_System.Domain.ValueObject
{
    public class Person
    {
        public int Id { get; }

        public Person (int id)
        {
            Id = id;
        }

        public Person Add (int id)
        {
            return new Person(id);
        }


    }
}

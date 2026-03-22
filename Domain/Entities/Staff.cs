using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_System.Domain.Entities
{
    public class Staff : Person
    {
        public string Position { get; set; }
        public int StaffId { get; set; }

        public Staff(int staffId, string firstName, string lastName, string position) : base (firstName, lastName)
        {
            this.Position = position;
            this.StaffId = staffId;
        }
    }
}

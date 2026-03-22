using Hotel_Reservation_System.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_System.Domain.Entities
{
    internal class Room
    {
        public int RoomNumber { get; private set; }
        public int Floor { get; private set; }
        public int Capacity { get; private set; }
        public RoomType Type { get; private set; }
        public decimal Price { get; private set; }

        public List<Guest> Guests { get; private set; } = new List<Guest>();

        public bool IsFree
        {
            get
            {
                if(Guests.Count == 0)
                {
                    return true;
                }
                return false;
            }
        }

        public Room(int roomNumber, int floor, int capacity, RoomType type, decimal price)
        {
            this.RoomNumber = roomNumber;
            this.Floor = floor;
            this.Capacity = capacity;
            this.Type = type;
            this.Price = price;
        }

        public bool AddGuest(Guest guest)
        {
            if (Guests.Count >= Capacity)
            {
                return false;
            }

            Guests.Add(guest);
            return true;
        }

        public void RemoveGuest(Guest guest)
        {
            if (Guests.Count > 0) Guests.Remove(guest);
            else throw new ArgumentException("There are no guests in this room");
        }

        public void ClearRoom()
        {
            Guests.Clear();
        }
    }
}

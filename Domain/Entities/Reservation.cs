using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_System.Domain.Entities
{
    //public class Reservation
    //{

    //    public decimal FinalPrice
    //    {
    //        get
    //        {
    //            decimal servicesPrice = 0;

    //            foreach (var service in Services)
    //            {
    //                servicesPrice += service.PricePerDay * service.DurationInDays;
    //            }

    //            return (Room.Price * Days) + servicesPrice;
    //        }
    //    }

    //    public Reservation(Room room, Guest guest, int days, int id)
    //    {
    //        if (days <= 0)
    //        {
    //            throw new ArgumentException("Days must be more than 0.");
    //        }

    //        this.Room = room;
    //        this.Guest = guest;
    //        this.Days = days;
    //        Id = id;
    //    }

    //    public void AddService(ReservationService service)
    //    {
    //        if (service.DurationInDays > Days)
    //        {
    //            throw new ArgumentException("Service duration cannot exceed reservation duration.");
    //        }

    //        Services.Add(service);
    //    }
    //}   
    public class Reservation
    {
        public Room Room { get; set; }
        public Guest Guest { get; set; } // На чие име е резервирана стаята (не кои са гостите в нея)
        public List<ReservationService> Services { get; set; } = new List<ReservationService>();
        public int Days { get; set; }
        public int Id { get; set; }

        // FOREIGN KEYS
        public int RoomId { get; set; }
        public int GuestId { get; set; }

        public Reservation()
        {

        }

        public Reservation(Room room, Guest guest, int days, int id)
        {
            if (days <= 0)
            {
                throw new ArgumentException("Days must be more than 0.");
            }

            Room = room;
            Guest = guest;
            Days = days;
            Id = id;
        }

        public decimal FinalPrice
        {
            get
            {
                decimal servicesPrice = 0;

                foreach (var service in Services)
                {
                    servicesPrice += service.PricePerDay * service.DurationInDays;
                }

                return (Room.Price * Days) + servicesPrice;
            }
        }

        public void AddService(ReservationService service)
        {
            if (service.DurationInDays > Days)
            {
                throw new ArgumentException("Service duration cannot exceed reservation duration.");
            }

            Services.Add(service);
        }
    }
}

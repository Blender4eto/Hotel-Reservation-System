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
    public class SqlRoomRepository : IRoomRepository
    {
        AppDbContext db;

        public SqlRoomRepository(AppDbContext db)
        {
            this.db = db;
        }
        public IReadOnlyList<Room> GetRooms()
        {
            return db.Rooms.ToList();
        }
        public Room GetRoomById(int roomId)
        {
            foreach (var room in db.Rooms)
            {
                if (room.Id == roomId)
                {
                    return room;
                }
            }
            throw new Exception("Room not found");
        }

        public void AddRoom(Room room)
        {
            var newRoom = new Room(
                room.RoomNumber,
                room.Floor,
                room.Capacity,
                room.Type
                //room.Price
            );

            db.Rooms.Add(newRoom);
            db.SaveChanges();
        }

        public void UpdateRoom(Room room)
        {
            db.SaveChanges();
        }
    }
}

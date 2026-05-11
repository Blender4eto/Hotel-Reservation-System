using Hotel_Reservation_System.Application;
using Hotel_Reservation_System.Application.Interfaces;
using Hotel_Reservation_System.Domain.Entities;
using Hotel_Reservation_System.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_System.Infrastructure.Json
{
    public class FileRoomRepository : IRoomRepository
    {
        public FileStorage storage;

       
        public FileRoomRepository(FileStorage storage)
        {
            this.storage = storage;
        }
        public IReadOnlyList<Room> GetRooms()
        {
            var db = storage.Load();
            return db.Rooms;
        }
        public Room GetRoomById(int roomId)
        {
            var db = storage.Load();
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
            var db = storage.Load();
 
            if (room.Id == 0)
            {
                var newRoom = new Room(
                    room.RoomNumber,
                    room.Floor,
                    room.Capacity,
                    room.RoomNumber, 
                    room.Type,
                    room.Price,
                    db.NextId++
                    );
                db.Rooms.Add(newRoom);
            }
            else
            {
                bool found = false;
                for (int i = 0; i < db.Rooms.Count; i++)
                {
                    if (db.Rooms[i].Id == room.Id)
                    {
                        db.Rooms[i] = room;
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    throw new Exception("Room not found");
                }
            }
            storage.Save(db);

        }
    }
}

using Hotel_Reservation_System.Application;
using Hotel_Reservation_System.Application.Interfaces;
using Hotel_Reservation_System.Domain.Entities;
using Hotel_Reservation_System.Infrastructure.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_System.Infrastructure
{
    public class FileRoomRepository : IRoomRepository
    {
        public FileStorage storage;

        //Trqbva da go pregledam(ne cheti tova denka)
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
            db.Rooms.Add(room);
        }
    }
}

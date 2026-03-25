using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Hotel_Reservation_System.Infrastructure
{
    public class FileStorage
    {
        private readonly string path;

        public FileStorage(string path = "hotel.json")
        {
            this.path = path;
        }
        public HotelStorage Load()
        {
            if (!File.Exists(path))
            {
                return new HotelStorage();
            }
            var json = File.ReadAllText(path);

            var storage = JsonSerializer.Deserialize<HotelStorage>(json);
            if (storage == null)
                throw new Exception("Deserialization return null.");

            return storage;
        }
        public void Save(HotelStorage storage)
        {
            var json = JsonSerializer.Serialize(storage);
          
            File.WriteAllText(path, json);
        }
    }
}

using Hotel_Reservation_System.Application.Interfaces;
using Hotel_Reservation_System.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_System.Infrastructure.Json
{
    public class FileStaffRepository : IStaffRepository
    {
        public FileStorage storage;

        //Trqbva da go pregledam(ne cheti tova denka)
        public FileStaffRepository(FileStorage storage)
        {
            this.storage = storage;
        }
        public IReadOnlyList<Staff> GetStaff()
        {
            var db = storage.Load();
            return db.Staff;
        }
        public Staff GetStaffById(int staffId)
        {
            var db = storage.Load();
            foreach (var staff in db.Staff)
            {
                if (staff.Id == staffId)
                {
                    return staff;
                }
            }
            throw new Exception("Staff not found");
        }
        public void AddStaff(Staff staff)
        {
            var db = storage.Load();
            db.Staff.Add(staff);
            storage.Save(db);
        }

        public void UpdateStaff(Staff staff)
        {
            var db = storage.Load();

            for (int i = 0; i < db.Staff.Count; i++)
            {
                if (db.Staff[i].Id == staff.Id)
                {
                    db.Staff[i] = staff;
                    storage.Save(db);
                    return;
                }
            }

            throw new Exception("Staff not found");
        }

        public void RemoveStaff(Staff staff)
        {
            var db = storage.Load();

            for (int i = 0; i < db.Staff.Count; i++)
            {
                if (db.Staff[i].Id == staff.Id)
                {
                    db.Staff.RemoveAt(i);
                    storage.Save(db);
                    return;
                }
            }

            throw new Exception("Staff not found");
        }

    }
}

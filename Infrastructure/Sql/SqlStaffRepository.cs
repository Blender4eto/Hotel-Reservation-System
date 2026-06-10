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
    public class SqlStaffRepository : IStaffRepository
    {
        AppDbContext db;

        //Trqbva da go pregledam(ne cheti tova denka)
        public SqlStaffRepository(AppDbContext db)
        {
            this.db = db;
        }
        public IReadOnlyList<Staff> GetStaff()
        {
            return db.Staffs.ToList();
        }
        public Staff GetStaffById(int staffId)
        {
            foreach (var staff in db.Staffs)
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
            db.Staffs.Add(staff);
            db.SaveChanges();
        }

        public void UpdateStaff(Staff staff)
        {
            db.SaveChanges();
        }

        public void RemoveStaff(Staff staff)
        {
            db.Staffs.Remove(staff);
            db.SaveChanges();
        }
    }
}

using Hotel_Reservation_System.Application;
using Hotel_Reservation_System.Domain.Entities;
using Hotel_Reservation_System.Domain.Enums;
using Hotel_Reservation_System.Application;

namespace Hotel_Reservation_System.ConsoleUI
{
    internal class HotelUI
    {
        private readonly HotelService hotelService;

        public HotelUI(HotelService hotelService)
        {
            this.hotelService = hotelService;
        }

        public void Run()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Menu();
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddRoom();
                        break;
                    case "2":
                        EditRoom();
                        break;
                    case "3":
                        ShowAvaibleRooms();
                        break;
                    case "4":
                        MakeReservation();
                        break;
                    case "5":
                        CancelReservation();
                        break;
                    case "6":
                        break;
                    case "7":
                        break;
                    case "8":
                        break;
                    case "9":
                        AddServiseToReservation();
                        break;
                    case "10":
                        ShowReciept();
                        break;
                    case "11":
                        break;
                    case "12":
                        ShowOccupancyRate();
                        break;
                    case "13":
                        ShowIncomeRate();
                        break;
                    case "14":
                        break;
                    case "15":
                        break;
                    case "16":
                        break;
                    case "17":
                        ShowMostPopularRooms();
                        break;
                    case "18":
                        ManageStaffMembers();
                        break;
                    case "19":
                        break;
                    case "20":
                        break;
                    case "21":
                        break;
                    case "22":
                        break;
                    case "0":
                        Console.WriteLine();
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }
        public void Menu()
        {
            Console.WriteLine("------ Hotel ------");
            Console.WriteLine("1. Add Room"); // типа определя цената на стаята
            Console.WriteLine("2. Edit Room"); // типа определя цената на стаята
            Console.WriteLine("3. Show Available Rooms");
            Console.WriteLine("4. Make a Reservation");
            Console.WriteLine("5. Cancel a Reservation");
            Console.WriteLine("6. Register a Guest");
            Console.WriteLine("7. Move in a Guest");
            Console.WriteLine("8. Move out a Guest");
            Console.WriteLine("9. Add an Service to Reservation"); //to an existing reservation
            Console.WriteLine("10. Show Reciept");
            Console.WriteLine("11. Reservations History");
            Console.WriteLine("12. Occupancy Rate");
            Console.WriteLine("13. Income Rate");
            Console.WriteLine("14. Manage a Reservation's Services"); // Добавяне на допълнителна услуга към списък с услуги - CAN SKIP!!!!!!!
            Console.WriteLine("15. Validate Reservation"); // Проверка дали определена резервация се припокрива с друга резервация за една и съща стая
            Console.WriteLine("16. Show all Guests");
            Console.WriteLine("17. Show Most Popular Rooms");
            Console.WriteLine("18. Manage Staff Members");
            Console.WriteLine("0. Exit");
            Console.WriteLine("-----------------------------");
            Console.Write("Choose an option: ");
        }

        //1
        private void AddRoom()
        {
            Console.Clear();
            Console.WriteLine("------ Adding Room ------");
            Console.WriteLine("Please enter room's");
            Console.Write("number: ");
            //int num = int.Parse(Console.ReadLine());
            if (!int.TryParse(Console.ReadLine(), out int num))
            {
                Console.WriteLine("Invalid room number.\n");
                return;
            }

            Console.Write("floor: ");
            //int floor = int.Parse(Console.ReadLine());
            if (!int.TryParse(Console.ReadLine(), out int floor))
            {
                Console.WriteLine("Invalid floor.\n");
                return;
            }

            Console.Write("capacity: ");
            //int capacity = int.Parse(Console.ReadLine());
            if (!int.TryParse(Console.ReadLine(), out int capacity))
            {
                Console.WriteLine("Invalid capacity.\n");
                return;
            }

            Console.WriteLine("\n------ Types ------");
            Console.WriteLine("0. Standard");
            Console.WriteLine("1. Comfort");
            Console.WriteLine("2. Luxury");
            Console.WriteLine("-------------------");
            Console.Write("Please choose a type: ");
            //int typeNum = int.Parse(Console.ReadLine());
            if (!int.TryParse(Console.ReadLine(), out int typeNum) || !Enum.IsDefined(typeof(RoomType), typeNum))
            {
                Console.WriteLine("Invalid room type.\n");
                return;
            }

            var type = (RoomType)typeNum;

            try
            {
                hotelService.AddRoom(num, floor, capacity, type);
                Console.Clear();
                Console.WriteLine("New room successfuly added.\n");
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine($"{ex.Message}\n");
            }
        }

        //2
        private void EditRoom()
        {
            Console.Clear();
            if (hotelService.Rooms.Count == 0)
            {
                Console.WriteLine("No rooms added yet.\n");
                return;
            }
            PrintRooms();
            Console.Write("Please enter room's id you desire to edit: ");
            if (!int.TryParse(Console.ReadLine(), out int editRoomId))
            {
                Console.WriteLine("Invalid room id.\n");
                return;
            }

            Room room;
            try
            {
                room = hotelService.GetRoomById(editRoomId);
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine($"{ex.Message}\n");
                return;
            }
            int roomNumber = room.RoomNumber;
            int floor = room.Floor;
            int capacity = room.Capacity;
            var type = room.Type;
            //decimal price = room.Price;

            Console.WriteLine("\n------ Editable: ------");
            Console.WriteLine("1. Room's number");
            Console.WriteLine("2. Room's floor");
            Console.WriteLine("3. Room's capacity");
            Console.WriteLine("4. Room's type");
            Console.WriteLine("-----------------------");
            Console.Write("Enter number of your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter new number for the room: ");
                    if (!int.TryParse(Console.ReadLine(), out roomNumber))
                    {
                        Console.WriteLine("Invalid room number.\n");
                        return;
                    }
                    break;
                case "2":
                    Console.Write("Enter new floor for the room: ");
                    if (!int.TryParse(Console.ReadLine(), out floor))
                    {
                        Console.WriteLine("Invalid floor.\n");
                        return;
                    }
                    break;
                case "3":
                    Console.Write("Enter new capacity for the room: ");
                    if (!int.TryParse(Console.ReadLine(), out capacity))
                    {
                        Console.WriteLine("Invalid capacity.\n");
                        return;
                    }
                    break;
                case "4":
                    Console.WriteLine("\n------ Types ------");
                    Console.WriteLine("0. Standard");
                    Console.WriteLine("1. Comfort");
                    Console.WriteLine("2. Luxury");
                    Console.WriteLine("-------------------");
                    Console.Write("Enter new type for the room: ");
                    if (!int.TryParse(Console.ReadLine(), out int typeNum) || !Enum.IsDefined(typeof(RoomType), typeNum))
                    {
                        Console.WriteLine("Invalid room type.\n");
                        return;
                    }
                    type = (RoomType)typeNum;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Returning to Menu.\n");
                    return;
            }

            try
            {
                hotelService.EditRoom(editRoomId, roomNumber, floor, capacity, type);
                Console.Clear();
                Console.WriteLine("Room successfully edited!\n");
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine($"{ex.Message}\n");
                return;
            }
        }

        //3
        private void ShowAvaibleRooms()
        {
            Console.Clear();
            if (hotelService.Rooms.Count == 0)
            {
                Console.WriteLine("No rooms added yet.\n");
                return;
            }
            Console.WriteLine("------------------------------------ Avaible Rooms: ----------------------------");
            var avaibleRooms = hotelService.Rooms.Where(r => r.IsFree).ToList();
            if (avaibleRooms.Count == 0)
            {
                Console.WriteLine("No avaible rooms at the moment.\n");
                return;
            }
            foreach (var room in avaibleRooms)
            {
                Console.WriteLine($"Id.{room.Id}: Number - {room.RoomNumber}, Floor - {room.Floor}, Capacity - {room.Capacity}, Type - {room.Type}, Price - {room.Price} Euro");
            }
            Console.WriteLine("--------------------------------------------------------------------------------\n");
        }


        //4
        //4
        private void MakeReservation()
        {
            Console.Clear();

            if (hotelService.Rooms.Count == 0)
            {
                Console.WriteLine("No rooms available.\n");
                return;
            }

            if (hotelService.GetGuests().Count == 0)
            {
                Console.WriteLine("No guests available.\n");
                return;
            }

            PrintRooms();
            Console.Write("Room id: ");
            if (!int.TryParse(Console.ReadLine(), out int roomId))
            {
                Console.WriteLine("Invalid room id.\n");
                return;
            }

            PrintGuests();

            Console.Write("Guest id: ");
            if (!int.TryParse(Console.ReadLine(), out int guestId))
            {
                Console.WriteLine("Invalid guest id.\n");
                return;
            }

            Console.Write("Days: ");
            if (!int.TryParse(Console.ReadLine(), out int days))
            {
                Console.WriteLine("Invalid days.\n");
                return;
            }

            try
            {
                var room = hotelService.GetRoomById(roomId);
                var guest = hotelService.GetGuestById(guestId);

                var reservation = new Reservation(room, guest, days, 0)
                {
                    RoomId = roomId,
                    GuestId = guestId
                };

                hotelService.AddReservation(reservation);

                Console.Clear();
                Console.WriteLine("Reservation created successfully.\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        
        //5
        private void CancelReservation()
        {
            Console.Clear();

            if (hotelService.Reservations.Count == 0)
            {
                Console.WriteLine("No reservations found.\n");
                return;
            }

            PrintReservations();

            Console.Write("Reservation id: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid id.\n");
                return;
            }

            try
            {
                hotelService.CancelReservation(id);

                Console.Clear();
                Console.WriteLine("Reservation cancelled.\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //6
        private void RegisterGuest()
        {
            Console.Clear();

            Console.Write("First name: ");
            string firstName = Console.ReadLine();

            Console.Write("Last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Phone number: ");
            string phoneNumber = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(phoneNumber))
            {
                Console.WriteLine("Invalid guest data.\n");
                return;
            }

            try
            {
                hotelService.AddGuest(firstName, lastName,phoneNumber);
                Console.Clear();
                Console.WriteLine("Guest registered successfully.\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //7
        private void MoveInGuest()
        {
            Console.Clear();

            PrintReservations();

            Console.Write("Reservation id: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid id.\n");
                return;
            }

            try
            {
                var reservation = hotelService.GetReservationById(id);

                if (!reservation.Room.IsFree)
                {
                    Console.WriteLine("Room already occupied.\n");
                    return;
                }

                hotelService.CheckIn(id);

                Console.Clear();
                Console.WriteLine("Guest checked in.\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
       
        //8
        private void MoveOutGuest()
        {
            Console.Clear();

            PrintReservations();

            Console.Write("Reservation id: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid id.\n");
                return;
            }

            try
            {
                hotelService.CheckOut(id);

                Console.Clear();
                Console.WriteLine("Guest checked out.\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //9
        private void AddServiseToReservation()
        {
            Console.Clear();
            if (hotelService.Reservations.Count == 0)
            {
                Console.WriteLine("No reservations added yet.\n");
                return;
            }
            PrintReservations();
            Console.Write("Please choose a reservation for reciept (id):");
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid reservation id.\n");
                return;
            }
            Console.Clear();

            Reservation reservation = null;
            try
            {
                reservation = hotelService.GetReservationById(choice);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            PrintAvailableServices();
            Console.Write("Choose a service you want to add: ");
            if (!int.TryParse(Console.ReadLine(), out int serviceId) || !Enum.IsDefined(typeof(ServiceType), serviceId))
            {
                Console.WriteLine("Invalid service.\n");
                return;
            }
            ServiceType serviceType = (ServiceType)serviceId;

            Console.Write("Enter number of duration: ");
            if (!int.TryParse(Console.ReadLine(), out int days))
            {
                Console.WriteLine("Invalid input.\n");
                return;
            }
            try
            {
                hotelService.AddServiceToReservation(reservation.Id, serviceType, days);

                Console.Clear();
                Console.WriteLine("Service successfully added to reservation.\n");
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine($"{ex.Message}\n");
            }
        }

        //10
        private void ShowReciept()
        {
            Console.Clear();
            if (hotelService.Reservations.Count == 0)
            {
                Console.WriteLine("No reservations added yet.\n");
                return;
            }
            PrintReservations();
            Console.Write("Please choose a reservation for reciept (id):");
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid reservation id.\n");
                return;
            }
            Console.Clear();

            Reservation reservation = null;
            try
            {
                reservation = hotelService.GetReservationById(choice);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            Console.WriteLine("Reservation details:");
            Console.WriteLine($"Id - {reservation.Id}");
            Console.WriteLine($"Guest - {reservation.Guest.FirstName} {reservation.Guest.LastName}");
            Console.WriteLine($"Room number - {reservation.Room.RoomNumber}");
            Console.WriteLine($"Days - {reservation.Days}");
            PrintReservationIncludedServices(reservation);
            Console.WriteLine($"Final price - {reservation.FinalPrice}");
            Console.WriteLine("\nPress Enter to cntinue.");
            Console.ReadLine();
            Console.Clear();
        }
        //11
        private void ShowReservationHistory()
        {
            Console.Clear();

            var reservations = hotelService.Reservations;

            if (reservations.Count == 0)
            {
                Console.WriteLine("No reservations.\n");
                return;
            }

            Console.WriteLine("------ History ------");

            foreach (var r in reservations)
            {
                Console.WriteLine(
                    $"Id.{r.Id}: Room {r.Room.RoomNumber}, " +
                    $"Guest {r.Guest.FirstName} {r.Guest.LastName}, " +
                    $"Days {r.Days}, Price {r.FinalPrice}");
            }

            Console.WriteLine("---------------------\n");
        }
        //12
        private void ShowOccupancyRate()
        {
            Console.Clear();
            if (hotelService.Rooms.Count == 0)
            {
                Console.WriteLine("No rooms added yet.\n");
                return;
            }

            int occupiedRooms = hotelService.GetOccupiedRoomsCount();
            int allRooms = hotelService.Rooms.Count;
            decimal occupancyRate = hotelService.GetOccupancyRate();

            Console.WriteLine("------ Occupancy Rate ------");
            Console.WriteLine($"Occupied rooms: {occupiedRooms} / {allRooms}");
            Console.WriteLine($"Occupancy rate: {occupancyRate:F2}%");
            Console.WriteLine("----------------------------\n");
        }

        //13
        private void ShowIncomeRate()
        {
            Console.Clear();
            if (hotelService.Reservations.Count == 0)
            {
                Console.WriteLine("No reservations added yet.\n");
                return;
            }

            decimal income = hotelService.GetIncomeRate();

            Console.WriteLine("------ Income Rate ------");
            Console.WriteLine($"Total income: {income} Euro");
            Console.WriteLine("-------------------------\n");
        }

        //14
        private void ManageReservationServices()
        {
            Console.Clear();

            Console.WriteLine("1. Add service");
            Console.WriteLine("2. Back");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                AddServiseToReservation();
            }
        }
        //15
        private void ValidateReservation()
        {
            Console.Clear();

            PrintReservations();

            Console.Write("Reservation id: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid id.\n");
                return;
            }

            try
            {
                var reservation = hotelService.GetReservationById(id);

                if (reservation.Room.IsFree)
                {
                    Console.WriteLine("Reservation is valid.");
                }
                else
                {
                    Console.WriteLine("Room is currently occupied.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //16
        private void ShowAllGuests()
        {
            Console.Clear();

            var guests = hotelService.GetGuests();

            if (guests.Count == 0)
            {
                Console.WriteLine("No guests.\n");
                return;
            }

            Console.WriteLine("------ Guests ------");

            foreach (var g in guests)
            {
                Console.WriteLine($"Id.{g.Id}: {g.FirstName} {g.LastName}");
            }

            Console.WriteLine("--------------------\n");
        }
        //17
        private void ShowMostPopularRooms()
        {
            Console.Clear();
            if (hotelService.Reservations.Count == 0)
            {
                Console.WriteLine("No reservations added yet.\n");
                return;
            }

            var popularRooms = hotelService.GetMostPopularRooms();

            if (popularRooms.Count == 0)
            {
                Console.WriteLine("No reserved rooms found.\n");
                return;
            }

            Console.WriteLine("-------------------------- Most Popular Rooms: --------------------------");
            foreach (var popularRoom in popularRooms)
            {
                var room = popularRoom.Room;
                Console.WriteLine($"Id.{room.Id}: Number - {room.RoomNumber}, Floor - {room.Floor}, Capacity - {room.Capacity}, Type - {room.Type}, Reservations - {popularRoom.ReservationCount}");
            }
            Console.WriteLine("-------------------------------------------------------------------------\n");
        }

        //18
        private void ManageStaffMembers()
        {
            Console.Clear();
            Console.WriteLine("------ Manage Staff Members ------");
            Console.WriteLine("1. Add Staff");
            Console.WriteLine("2. Edit Staff");
            Console.WriteLine("3. Remove Staff");
            Console.WriteLine("----------------------------------");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddStaff();
                    break;
                case "2":
                    EditStaff();
                    break;
                case "3":
                    RemoveStaff();
                    break;
                default:
                    Console.WriteLine("Invalid choice.\n");
                    break;
            }
        }

        //18.1
        private void AddStaff()
        {
            Console.Clear();
            Console.WriteLine("------ Add Staff ------");

            Console.Write("First name: ");
            string firstName = Console.ReadLine();

            Console.Write("Last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Position: ");
            string position = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(position))
            {
                Console.WriteLine("Some of fields are incorrect.\n");
                return;
            }

            try
            {
                hotelService.AddStaff(firstName, lastName, position);
                Console.Clear();
                Console.WriteLine("Staff member successfully added.\n");
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine($"{ex.Message}\n");
            }
        }

        //18.2
        private void EditStaff()
        {
            Console.Clear();
            if (hotelService.GetStaff().Count == 0)
            {
                Console.WriteLine("No staff members added yet.\n");
                return;
            }

            PrintStaff();
            Console.Write("Please enter staff id you desire to edit: ");
            if (!int.TryParse(Console.ReadLine(), out int staffId))
            {
                Console.WriteLine("Invalid staff id.\n");
                return;
            }

            Console.Write("First name: ");
            string firstName = Console.ReadLine();

            Console.Write("Last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Position: ");
            string position = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(position))
            {
                Console.WriteLine("Some of fields are incorrect.\n");
                return;
            }

            try
            {
                hotelService.EditStaff(staffId, firstName, lastName, position);
                Console.Clear();
                Console.WriteLine("Staff member successfully edited.\n");
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine($"{ex.Message}\n");
            }
        }

        //18.3
        private void RemoveStaff()
        {
            Console.Clear();
            if (hotelService.GetStaff().Count == 0)
            {
                Console.WriteLine("No staff members added yet.\n");
                return;
            }

            PrintStaff();
            Console.Write("Please enter staff id you desire to remove: ");
            if (!int.TryParse(Console.ReadLine(), out int staffId))
            {
                Console.WriteLine("Invalid staff id.\n");
                return;
            }

            try
            {
                hotelService.RemoveStaff(staffId);
                Console.Clear();
                Console.WriteLine("Staff member successfully removed.\n");
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine($"{ex.Message}\n");
            }
        }



        //Printing Methods
        private void PrintStaff()
        {
            Console.WriteLine("----------------------- Staff Members: -----------------------");
            foreach (var staff in hotelService.GetStaff())
            {
                Console.WriteLine($"Id.{staff.Id}: {staff.FirstName} {staff.LastName}, Position - {staff.Position}");
            }
            Console.WriteLine("--------------------------------------------------------------\n");
        }
        private void PrintRooms()
        {
            Console.WriteLine("-------------------------------------- Rooms: ----------------------------------");
            foreach (var room in hotelService.Rooms)
            {
                Console.WriteLine($"Id.{room.Id}: Number - {room.RoomNumber}, Floor - {room.Floor}, Capacity - {room.Capacity}, Type - {room.Type}, Price - {room.Price} Euro");
            }
            Console.WriteLine("--------------------------------------------------------------------------------\n");
        }
        private void PrintReservations()
        {
            Console.WriteLine("-------------------------------------- Reservations: ----------------------------------");
            foreach (var res in hotelService.Reservations)
            {
                Console.WriteLine($"Id.{res.Id}: Room number - {res.Room.RoomNumber}, Guest - {res.Guest.FirstName} {res.Guest.LastName}, Days - {res.Days}, Price - {res.FinalPrice}");
            }
            Console.WriteLine("---------------------------------------------------------------------------------------\n");
        }
        private void PrintReservationIncludedServices(Reservation reservation)
        {
            Console.WriteLine("----------------------------------- Services: -------------------------------");
            foreach (var res in reservation.Services)
            {
                Console.WriteLine($"Id: {res.Id},Type - {res.Type}, Duration - {res.DurationInDays} Days, Total price - {res.PricePerDay * res.DurationInDays}");
            }
            Console.WriteLine("-----------------------------------------------------------------------------\n");
        }
        private void PrintAvailableServices()
        {
            Console.WriteLine("----------------------- Services: -------------------");
            int id = 0;
            foreach (ServiceType service in Enum.GetValues(typeof(ServiceType)))
            {
                id = (int)service;
                decimal price = new ReservationService { Type = service }.PricePerDay;
                Console.WriteLine($"Id - {id},Service - {service}, Price - {price}");
            }
            Console.WriteLine("-----------------------------------------------------\n");
        }
        private void PrintGuests()
        {
            Console.WriteLine("----------------------- Guests: -----------------------");
            foreach (var guest in hotelService.GetGuests())
            {
                Console.WriteLine($"Id.{guest.Id}: {guest.FirstName} {guest.LastName}, Phone - {guest.PhoneNumber}");
            }
            Console.WriteLine("-------------------------------------------------------\n");
        }
    }
}



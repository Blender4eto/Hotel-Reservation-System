using Hotel_Reservation_System.Application;
using Hotel_Reservation_System.Application.Interfaces;
using Hotel_Reservation_System.Domain.Entities;
using Hotel_Reservation_System.Domain.Enums;
using Hotel_Reservation_System.Infrastructure.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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
                        break;
                    case "5":
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
                        break;
                    case "13":
                        break;
                    case "14":
                        break;
                    case "15":
                        break;
                    case "16":
                        break;
                    case "17":
                        break;
                    case "18":
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
            if(hotelService.Rooms.Count == 0)
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
                reservation = hotelService.GerReservationById(choice);
            }
            catch(Exception ex)
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



        //Printing Methods
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
                Console.WriteLine($"Id: {res.Id},Type - {res.Type}, Duration - {res.DurationInDays} Days, Total price - {res.PricePerDay*res.DurationInDays}");
            }
            Console.WriteLine("-----------------------------------------------------------------------------\n");
        }
        private void PrintAvailableServices()
        {
            Console.WriteLine("----------------------- Services: -------------------");
            int id = 0;
            foreach (ServiceType service in Enum.GetValues(typeof(ServiceType)))
            {
                id++;
                decimal price = new ReservationService{ Type = service }.PricePerDay;
                Console.WriteLine($"Id - {id},Service - {service}, Price - {price}");
            }
            Console.WriteLine("-----------------------------------------------------\n");
        }
    }
}

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
using System.Text;
using System.Threading.Tasks;

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
                        CalculatePrice();
                        break;
                    case "10":
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
            Console.WriteLine("9. Calculate a Price");
            Console.WriteLine("10. Add an Additional Service"); //to an existing reservation
            Console.WriteLine("11. Show Reciept");
            Console.WriteLine("12. Reservations History");
            Console.WriteLine("13. Occupancy Rate");
            Console.WriteLine("14. Income Rate");
            Console.WriteLine("15. Manage a Reservation's Services"); // Добавяне на допълнителна услуга към списък с услуги - CAN SKIP!!!!!!!
            Console.WriteLine("16. Validate Reservation"); // Проверка дали определена резервация се припокрива с друга резервация за една и съща стая
            Console.WriteLine("17. Show all Guests");
            Console.WriteLine("18. Show Most Popular Rooms");
            Console.WriteLine("19. Manage Staff Members");
            Console.WriteLine("0. Exit");
            Console.WriteLine("-----------------------------");
            Console.Write("Choose an option: ");
        }

        private void AddRoom()
        {
            Console.Clear();
            Console.WriteLine("------ Adding Room ------");
            Console.WriteLine("Please enter room's");
            Console.Write("number: ");
            int num = int.Parse(Console.ReadLine());

            Console.Write("floor: ");
            int floor = int.Parse(Console.ReadLine());

            Console.Write("capacity: ");
            int capacity = int.Parse(Console.ReadLine());

            Console.WriteLine("\n------ Types ------");
            Console.WriteLine("0. Standard");
            Console.WriteLine("1. Comfort");
            Console.WriteLine("2. Luxury");
            Console.WriteLine("-------------------");
            Console.Write("Please choose a type: ");
            int typeNum = int.Parse(Console.ReadLine());

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

        //not ready yet
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
            int editRoomId = int.Parse(Console.ReadLine());

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
                    roomNumber = int.Parse(Console.ReadLine());
                    break;
                case "2":
                    Console.Write("Enter new floor for the room: ");
                    floor = int.Parse(Console.ReadLine());
                    break;
                case "3":
                    Console.Write("Enter new capacity for the room: ");
                    capacity = int.Parse(Console.ReadLine());
                    break;
                case "4":
                    Console.WriteLine("\n------ Types ------");
                    Console.WriteLine("0. Standard");
                    Console.WriteLine("1. Comfort");
                    Console.WriteLine("2. Luxury");
                    Console.WriteLine("-------------------");
                    Console.Write("Enter new type for the room: ");
                    int typeNum = int.Parse(Console.ReadLine());
                    type = (RoomType)typeNum;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Returning to Menu.");
                    return;
            }

            try
            {
                hotelService.EditRoom(editRoomId, roomNumber, floor, capacity, type); //it isnt saving, should work if saves are made, not sure how to save
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

        private void CalculatePrice()
        {
            //not sure what to calculate exactly yet
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
    }
}

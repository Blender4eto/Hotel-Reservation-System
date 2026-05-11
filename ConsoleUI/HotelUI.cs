using Hotel_Reservation_System.Application;
using Hotel_Reservation_System.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Reservation_System.Domain.Enums;
using Hotel_Reservation_System.Domain.Entities;
using Hotel_Reservation_System.Infrastructure.Json;

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
            Console.WriteLine("1. Add Room");
            Console.WriteLine("2. Edit Room"); // Не се променя вида на стаята заради №15
            Console.WriteLine("3. Show Avaible Rooms");
            Console.WriteLine("4. Make a Reservation");
            Console.WriteLine("5. Cancel a Reservation");
            Console.WriteLine("6. Register a Guest");
            Console.WriteLine("7. Move in a Guest");
            Console.WriteLine("8. Move out a Guest");
            Console.WriteLine("9. Calculate a Price");
            Console.WriteLine("10. Add an Additional Service");
            Console.WriteLine("11. Show Reciept");
            Console.WriteLine("12. Reservations History");
            Console.WriteLine("13. Occupancy Rate");
            Console.WriteLine("14. Income Rate");
            Console.WriteLine("15. Manage a Room's Type"); // Промяна дали стая е нормална, комфортна или кусозна
            Console.WriteLine("16. Manage a Reservation's Services"); // Добавяне на допълнителна услуга към резервация
            Console.WriteLine("17. Validate Reservation"); // Проверка дали определена резервация се припокрива с друга резервация за една и съща стая
            Console.WriteLine("18. Show all Guests");
            Console.WriteLine("19. Show Most Popular Rooms");
            Console.WriteLine("20. Hire Staff Member");
            Console.WriteLine("21. Edit Staff Member");
            Console.WriteLine("22. Fire Staff Member");
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

            Console.Write("price: ");
            decimal price = decimal.Parse(Console.ReadLine());

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
                hotelService.AddRoom(num, floor, capacity, type, price);
                Console.Clear();
                Console.WriteLine("\nNew room successfuly added.\n");
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine($"{ex.Message}\n");
            }
        }

        private void EditRoom()
        {
            Console.Clear();
            PrintRooms();
            Console.Write("Please enter room's id you desire to edit: ");
            int editRoomId = int.Parse(Console.ReadLine());

            Console.WriteLine("\n------ Editable: ------");
            Console.WriteLine("1. Room's number");
            Console.WriteLine("2. Room's floor");
            Console.WriteLine("3. Room's capacity");
            Console.WriteLine("4. Room's type");
            Console.WriteLine("5. Room's price");
            Console.WriteLine("-----------------------");
            Console.Write("Enter number of your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("\nEnter new number for the room: ");
                    int newNum = int.Parse(Console.ReadLine());
                    break;
                case "2":
                    Console.Write("\nEnter new floor for the room: ");
                    int newFloor = int.Parse(Console.ReadLine());
                    break;
                case "3":
                    Console.Write("\nEnter new capacity for the room: ");
                    int newCapacity = int.Parse(Console.ReadLine());
                    break;
                case "4":
                    Console.WriteLine("\n------ Types ------");
                    Console.WriteLine("0. Standard");
                    Console.WriteLine("1. Comfort");
                    Console.WriteLine("2. Luxury");
                    Console.WriteLine("-------------------");
                    Console.Write("Choose new type for the room: ");
                    int newType = int.Parse(Console.ReadLine());
                    break;
                case "5":
                    Console.Write("Enter new price for the room: ");
                    int newPrice = int.Parse(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("Invalid choice. Returning to Menu.");
                    break;
            }
        }

        private void PrintRooms()
        {
            Console.WriteLine("------ Rooms: ------");
            foreach (var room in hotelService.Rooms)
            {
                Console.WriteLine($"Id: {room.Id}, Number: {room.RoomNumber}, Floor: {room.Floor}, Capacity: {room.Capacity}, Type: {room.Type}, Price: {room.Price}€");
            }
            Console.WriteLine("--------------------");
        }
    }
}

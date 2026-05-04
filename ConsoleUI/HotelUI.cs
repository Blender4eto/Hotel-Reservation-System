using Hotel_Reservation_System.Application;
using System;
using System.Collections.Generic;
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
                        break;
                    case "2":
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
    }
}

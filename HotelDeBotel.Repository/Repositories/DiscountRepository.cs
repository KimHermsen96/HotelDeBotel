using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelDeBotel.Domain;
using HotelDeBotel.Repository.IRepositories;

namespace HotelDeBotel.Repository.Repositories
{
    public class DiscountRepository :  IDiscountRepository
    {
        private readonly Random _random;
        public decimal Discount { get; set; }
        public int RandomNumber { get; set; }

        public DiscountRepository()
        {
            _random = new Random();
        }

        public DiscountRepository(Random random)
        {
            _random = random;
        }

        public decimal MondayAndTuesdayDiscount(DateTime date, decimal price)
        {
            if (date.DayOfWeek == DayOfWeek.Monday || date.DayOfWeek == DayOfWeek.Tuesday)
            {
                Discount = price * 15 / 100;
                price -= Discount;
            }

            return Math.Round(price, 2);
        }

        public decimal WeekOfTheYearDiscount(DateTime date, decimal price)
        {
            CultureInfo cultureInfo = new CultureInfo("NL");
            Calendar calendar = cultureInfo.Calendar;
            CalendarWeekRule calendarWeekRule = cultureInfo.DateTimeFormat.CalendarWeekRule;
            DayOfWeek firstDayOfWeek = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            int weekOfYear = calendar.GetWeekOfYear(date, calendarWeekRule, firstDayOfWeek);

            if (weekOfYear % 2 != 0)
            {
                Discount = price * 3 / 100;
                price -= Discount;
            }

            return Math.Round(price, 2);
        }

        public decimal NumberOfRoomsDiscount(int numberOfRooms, decimal price)
        {

            Discount = price * numberOfRooms / 100;
            price -= Discount;

            return Math.Round(price, 2);
        }


        public decimal AlphabeticDiscount(decimal price, List<Guest> guests)
        {
            foreach (Guest guest in guests)
            {
                bool inName = false;

                for (char alfabetLetter = 'a'; alfabetLetter <= 'z'; alfabetLetter++)
                {
                    foreach (char letterInName in guest.Name.ToLower())
                    {
                        if (alfabetLetter == letterInName)
                        {
                            //2% extra koring. 
                            inName = true;
                            Discount = price * 2 / 100;
                            price -= Discount;
                            break;
                        }
                    }

                    if (inName == false)
                    {
                        break;
                    }
                    else
                    {
                        inName = false;
                    }
                }
            }

            return Math.Round(price, 2);
        }

        public decimal DiceDubbelerDiscount(decimal price, decimal initalPrice)
        {
            decimal currentDiscountProcentage = CurrentDiscountCalculator(price, initalPrice);
            int randomDice = RandomNum();

            Discount = 100 - (currentDiscountProcentage * randomDice);

            price = initalPrice * Discount / 100;
            return Math.Round(price, 2);
        }

        public int RandomNum()
        {
            RandomNumber = _random.Next(1, 7);
            return RandomNumber;
        }

        public decimal CurrentDiscountCalculator(decimal price, decimal initalPrice)
        {
            //geeft het huidige procent discount terug. 
            return 100 - (price * 100 / initalPrice);
        }

        public decimal CheckDiscount(decimal price, decimal initalPrice)
        {
            decimal currentDiscountProcentage = CurrentDiscountCalculator(price, initalPrice);

            if (currentDiscountProcentage >= 60)
            {
                price = initalPrice * 40 / 100;
            }

            return Math.Round(price, 2);
        }
    }
}

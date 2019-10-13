using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelDeBotel.Domain;

namespace HotelDeBotel.Repository.IRepositories
{
    public interface IDiscountRepository
    {
        decimal Discount { get; set; }
        decimal MondayAndTuesdayDiscount(DateTime date, decimal price);
        decimal WeekOfTheYearDiscount(DateTime date, decimal price);
        decimal NumberOfRoomsDiscount(int numberOfRooms, decimal price);
        decimal AlphabeticDiscount(decimal price, List<Guest> guests);
        decimal DiceDubbelerDiscount(decimal price, decimal initalPrice);
        decimal CurrentDiscountCalculator(decimal price, decimal initalPrice);
        decimal CheckDiscount(decimal price, decimal initalPrice);
    }
}

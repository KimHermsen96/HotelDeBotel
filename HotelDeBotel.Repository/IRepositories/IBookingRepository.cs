using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelDeBotel.Domain;

namespace HotelDeBotel.Repository.IRepositories
{
    public interface IBookingRepository :  IRepository<Booking>
    {
        bool IsAvailable(int roomId, DateTime date);
        List<Booking> GetAllBookingInfo();
        List<Booking> GetAllBookingsOfUser(string id);
        Booking FindBooking(int? id);
    }
}

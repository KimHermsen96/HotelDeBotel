using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelDeBotel.Domain;
using HotelDeBotel.Repository.IRepositories;
using HotelDeBotel.Repository.Persistance;

namespace HotelDeBotel.Repository.Repositories
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        private readonly HotelContext _context;

        public decimal Discount { get; set; }
        public int RandomNumber { get; set; }

        public BookingRepository(HotelContext context) : base(context)
        {
            _context = context;
        }

        public bool IsAvailable(int roomId, DateTime date)
        {

            foreach (var a in GetAllBookingInfo())
            {
                if (a.Date == date && a.Room.Id == roomId) return false;
            }

            return true;
        }

        public List<Booking> GetAllBookingInfo()
        {
            return _context.Bookings
                .Include(r => r.Room)
                .Include(g => g.Guests)
                .ToList();
        }

        public List<Booking> GetAllBookingsOfUser(string id)
        {
            return _context.Bookings
                .Where(x => x.User.Id == id)
                .Include(r => r.Room)
                .Include(g => g.Guests)
                .ToList();
        }

        public Booking FindBooking(int? id)
        {
            return _context.Bookings
                .Include(r => r.Room)
                .Include(g => g.Guests)
                .First(x => x.Id == id);
        }
    }
} 

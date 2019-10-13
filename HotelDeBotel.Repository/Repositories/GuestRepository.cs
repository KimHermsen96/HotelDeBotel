using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelDeBotel.Domain;
using HotelDeBotel.Repository.IRepositories;
using HotelDeBotel.Repository.Persistance;

namespace HotelDeBotel.Repository.Repositories
{
    public class GuestRepository : Repository<Guest>, IGuestRepository
    {
        private readonly HotelContext _context;

        public GuestRepository(HotelContext context) : base(context)
        {
            _context = context;
        }

        public List<Guest> FindGuestsWithBooking(int? bookingId)
        {
            return _context.Guests
                .Where(x => x.BookingId == bookingId)
                .ToList();
        }
    }
}

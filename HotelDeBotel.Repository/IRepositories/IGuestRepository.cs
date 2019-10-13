using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelDeBotel.Domain;

namespace HotelDeBotel.Repository.IRepositories
{
    public interface IGuestRepository : IRepository<Guest>
    {
        List<Guest> FindGuestsWithBooking(int? bookingId); 
    }
}

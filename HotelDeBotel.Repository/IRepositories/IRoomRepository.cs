using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelDeBotel.Domain;

namespace HotelDeBotel.Repository.IRepositories
{
    public interface IRoomRepository : IRepository<Room>
    {
        List<Room> RecommendedRooms(); 
    }
}
    
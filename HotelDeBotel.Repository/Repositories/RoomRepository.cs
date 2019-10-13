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
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(HotelContext context) : base(context)
        {
        }

        public List<Room> RecommendedRooms()
        {
            return GetAll().GetRange(0, 3);
        }
    }
}

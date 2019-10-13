using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using HotelDeBotel.Domain;
using HotelDeBotel.Repository.IRepositories;
using HotelDeBotel.Repository.Persistance;

namespace HotelDeBotel.Repository.Repositories
{
    public class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        public UserRepository(HotelContext context) : base(context)
        {
        }
    }
}

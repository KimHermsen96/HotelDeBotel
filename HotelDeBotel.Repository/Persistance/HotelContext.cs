using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelDeBotel.Domain;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HotelDeBotel.Repository.Persistance
{
    public class HotelContext : IdentityDbContext<ApplicationUser>
    {
        public HotelContext() : base("name=DefaultConnection", throwIfV1Schema: false)
        {

        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set;}
        public DbSet<Guest> Guests { get; set;}

        public static HotelContext Create()
        {
            return new HotelContext();
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    var en = failure.Entry.Entity;
                    sb.Append($"{failure.Entry.Entity.GetType()} failed validation \n");
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb, ex
                );
            }
        }
    }
}

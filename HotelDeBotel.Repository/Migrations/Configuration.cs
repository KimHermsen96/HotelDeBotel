using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HotelDeBotel.Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HotelDeBotel.Repository.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HotelDeBotel.Repository.Persistance.HotelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(HotelDeBotel.Repository.Persistance.HotelContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            Room room1;
            Room room2;

            context.Rooms.AddOrUpdate(

            room1 = new Room()
                {
                    Id = 1,
                    Name = "Underwater suite",
                    Size = 2,
                    Price = 100.00m,
                    Image = "https://freshome.com/wp-content/uploads/2013/07/Dubai-Underwater-Hotel-Rooms.jpg"
                },
                room2 = new Room()
                {
                    Id = 2,
                    Name = "Seamans suite",
                    Size = 2,
                    Price = 180.00m,
                    Image = "https://www.quertime.com/wp-content/uploads/2014/05/most_unusual_hotels.jpg"
                },
                new Room()
                {
                    Name = "Rooftop suite",
                    Size = 3,
                    Price = 120.00m,
                    Image = "http://sectordefinition.com/wp-content/uploads/2013/07/Kakslauttanen-Finland.jpeg"
                },
                new Room()
                {
                    Name = "Big blue world suite",
                    Size = 5,
                    Price = 500.00m,
                    Image = "https://cdn.lolwot.com/wp-content/uploads/2014/12/20-of-the-most-amazing-hotel-rooms-in-the-world.jpg"
                },
                new Room()
                {
                    Name = "Basement suite",
                    Size = 2,
                    Price = 90.00m,
                    Image = "https://static.boredpanda.com/blog/wp-content/uploads/2015/01/unusual-themed-hotels-13__880.jpg"
                },
                new Room()
                {
                    Name = "Moulin rouge",
                    Size = 2,
                    Price = 100.00m,
                    Image = "https://www.rd.com/wp-content/uploads/2016/10/unusual-hotels-Featherbed.jpg"
                },
                new Room()
                {
                    Name = "Flintstones suite",
                    Size = 2,
                    Price = 80.00m,
                    Image = "https://img.allw.mn/content/travel/2013/08/1_the-caveman-room_600x426.jpg"
                },
                new Room()
                {
                    Name = "Mermade suite",
                    Size = 2,
                    Price = 100.00m,
                    Image = "https://t-ec.bstatic.com/data/xphoto/1182x887/303/30357696.jpg?size=S"
                }
            );


            //context.SaveChanges();

            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            string[] roleNames = { "User", "Employee" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                if (!RoleManager.RoleExists(roleName))
                {
                    roleResult = RoleManager.Create(new IdentityRole(roleName));
                }
            }

            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);

            var employee = new ApplicationUser()
            {
                Id = "1",
                Email = "employee@hotmail.com",
                UserName = "employee@hotmail.com"
            };
            manager.Create(employee, "Test123!");

            var user = new ApplicationUser()
            {
                Id = "2",
                Email = "user@hotmail.com",
                UserName = "user@hotmail.com"
            };
            manager.Create(user, "Test123!");

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            UserManager.AddToRole("1", "Employee");
            UserManager.AddToRole("2", "User");

            context.Bookings.AddOrUpdate(
                new Booking()
                {
                    Date = new DateTime(2019, 12, 18),
                    Price = 100.00m,
                    RoomId = 1,
                    User = user,
                    Guests = new List<Guest>()
                    {
                        new Guest()
                        {
                            Name = "Jeroen Hartman",
                            HouseNumber = 204,
                            Addition = "H",
                            EmailAddress = "Jeroentje@hotmail.com",
                            Zipcode = "3461ED"
                        },
                    }
                },
                new Booking()
                {
                    Date = new DateTime(2019, 11, 11),
                    Price = 100.00m,
                    RoomId = 2,
                    User = user,
                    Guests = new List<Guest>()
                    {
                        new Guest()
                        {
                            Name = "Karen Versteeg",
                            HouseNumber = 12, 
                            Addition = "a",
                            EmailAddress = "Karen_v@hotmail.com",
                            Zipcode = "1275ED"
                        },
                        new Guest()
                        {
                            Name = "Marc Jansen",
                            HouseNumber = 12,
                            Addition = "a",
                            EmailAddress = "MarcJansen123@hotmail.com",
                            Zipcode = "1275ED"
                        },
                    }
                }
            );

            context.SaveChanges();
        }
    }
}

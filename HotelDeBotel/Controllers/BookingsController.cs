using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelDeBotel.Domain;
using HotelDeBotel.Models;
using HotelDeBotel.Repository.IRepositories;
using HotelDeBotel.Repository.Persistance;
using Microsoft.AspNet.Identity;

namespace HotelDeBotel.Controllers
{
    public class BookingsController : Controller
    {
        private readonly IBookingRepository _bookings;
        private readonly IRoomRepository _rooms;
        private readonly IUserRepository _users;
        private readonly HotelContext _context;
        private readonly IGuestRepository _guests;
        private readonly IDiscountRepository _discountRepo;

        public BookingsController(IBookingRepository bookings, IRoomRepository rooms, IUserRepository users, HotelContext context, IGuestRepository guests, IDiscountRepository discountRepo)
        {
            _bookings = bookings;
            _rooms = rooms;
            _users = users;
            _context = context;
            _guests = guests;
            _discountRepo = discountRepo;
        }
        // GET: Bookings
        public ActionResult Index()
        {
            List<Booking> model;
          
            if (User.IsInRole("Employee"))
            {
                model = _bookings.GetAllBookingInfo();
            }
            else
            {
                model = _bookings.GetAllBookingsOfUser(User.Identity.GetUserId());
            }

            return View(model);
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Booking booking = _bookings.FindBooking(id);

            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        public ActionResult Create(int id)
        {
            var model = new BookingViewModel()
            {
                Room = _rooms.Find(id),
            };

            return View(model);
        }

        public ActionResult BookingContactDetails(BookingViewModel bookingvm)
        {

            bool isAvailable = _bookings.IsAvailable(bookingvm.Room.Id, bookingvm.Date);

            if (bookingvm.Date >= DateTime.Today && isAvailable && bookingvm.NumberOfGuests <= bookingvm.Room.Size)
            {
                bookingvm.Room = _rooms.Find(bookingvm.Room.Id);
                return View("BookingContactDetails",bookingvm);
            }

            if (bookingvm.NumberOfGuests > bookingvm.Room.Size) ModelState.AddModelError("NumberOfGuests", "Er passen maximaal " +  bookingvm.Room.Size + " mensen op deze kamer");
            if (bookingvm.Date < DateTime.Now) ModelState.AddModelError("Date" , "De datum moet vandaag zijn of in de toekomst liggen.");
            if (!isAvailable)ModelState.AddModelError("Date", "Deze datum is al bezet.");

            return View("Create", bookingvm);
        }

        public ActionResult BookingCalculateDiscount(BookingViewModel bookingvm)
        {
       
            decimal initalPrice = _rooms.Find(bookingvm.Room.Id).Price;
            var date =  bookingvm.Date;
            
            var newPrice= _discountRepo.MondayAndTuesdayDiscount(date, initalPrice);
            newPrice = _discountRepo.WeekOfTheYearDiscount(date, newPrice);
            newPrice = _discountRepo.NumberOfRoomsDiscount(_rooms.GetAll().Count(), newPrice);
            newPrice = _discountRepo.AlphabeticDiscount(newPrice, bookingvm.Guests);

            newPrice = _discountRepo.DiceDubbelerDiscount(newPrice, initalPrice);
            newPrice = _discountRepo.CheckDiscount(newPrice, initalPrice);
            
            bookingvm.Room = _rooms.Find(bookingvm.Room.Id);
            bookingvm.Price = newPrice;
            bookingvm.Discount = Math.Round(_discountRepo.CurrentDiscountCalculator(newPrice, initalPrice), 2);
          
            return View(bookingvm);
        }


        public ActionResult SaveBooking(BookingViewModel bookingvm)
        {

            var booking = new Booking()
            {
                RoomId =  bookingvm.Room.Id,
                Date = bookingvm.Date,
                Guests = bookingvm.Guests,
                Price =  bookingvm.Price,
                User = _users.Find(User.Identity.GetUserId())
            };

            _context.Bookings.Add(booking);
            _context.SaveChanges();

            return RedirectToAction("index", "Rooms"); 
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = _bookings.Find(id);
            
            if (booking == null)
            {
                return HttpNotFound();
            }
            var guests = _guests.FindGuestsWithBooking(id);

            foreach (var guest in guests)
            {
                _guests.Remove(guest);
            }

            _bookings.Remove(booking);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

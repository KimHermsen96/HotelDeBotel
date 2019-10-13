using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelDeBotel.Domain;
using HotelDeBotel.Models;
using HotelDeBotel.Repository.IRepositories;
using HotelDeBotel.Repository.Persistance;
using HotelDeBotel.Repository.Repositories;
using Microsoft.AspNet.Identity;
using ApplicationUser = HotelDeBotel.Domain.ApplicationUser;

namespace HotelDeBotel.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomRepository _rooms;
        private readonly HotelContext _context;

        private readonly IUserRepository _users;
        // GET: Rooms
        public RoomsController(IRoomRepository rooms, HotelContext context, IUserRepository users)
        {
            _rooms = rooms;
            _context = context;
            _users = users;
        }

        public ActionResult Index()
        {
            RoomsViewModel roomsvm = new RoomsViewModel()
            {
                Rooms = _rooms.GetAll(),
                User = _users.Find(User.Identity.GetUserId())
            };
         
            return View("Index", roomsvm);
        }

        // GET: Rooms/Details/5
        public ActionResult ReserveRoom(int? id)
        {
            return RedirectToAction("Create", "Bookings", new { id = id });
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = _rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View("Details", room);
        }

        // GET: Rooms/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Size,Price,Image")] Room room)
        {
            if (ModelState.IsValid)
            {
                _rooms.Add(room);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View("Create", room);
        }

        // GET: Rooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Room room = _rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View("Edit",room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Size,Price,Image")] Room room)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(room).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(room);
        }

        // GET: Rooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = _rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View("Delete",room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Room room = _rooms.Find(id);
            _rooms.Remove(room);
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

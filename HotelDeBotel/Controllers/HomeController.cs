using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelDeBotel.Repository.IRepositories;

namespace HotelDeBotel.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRoomRepository _rooms;

        public HomeController(IRoomRepository rooms)
        {
            _rooms = rooms;
        }

        public ActionResult Index()
        {
            var recommendedRooms = _rooms.RecommendedRooms(); 
            return View("Index", recommendedRooms);
        }
    }
}
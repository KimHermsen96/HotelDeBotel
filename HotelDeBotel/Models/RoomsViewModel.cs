using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelDeBotel.Domain;

namespace HotelDeBotel.Models
{
    public class RoomsViewModel
    {
        public List<Room> Rooms { get; set; }
        public ApplicationUser User { get; set; }
    }
}
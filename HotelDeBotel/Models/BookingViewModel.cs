using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using HotelDeBotel.Domain;

namespace HotelDeBotel.Models
{
    public class BookingViewModel
    {
        public List<Guest> Guests { get; set; }
        public Room Room { get; set; }

        [Required(ErrorMessage = "Een boeking bevat altijd een datum.")]
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }

        [Required, Range(1, 5, ErrorMessage = "Een kamer kan maximaal 5 gasten hebben.")]
        public int NumberOfGuests { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelDeBotel.Domain
{
    public class Booking : BaseEntity
    {
        [ForeignKey("BookingId")]
        [Required(ErrorMessage = "Een boeking bevat altijd een of meerdere gasten.")]
        public List<Guest> Guests { get; set; }

        public Room Room { get; set; }

        public int RoomId { get; set; }

        [Required(ErrorMessage = "Een boeking bevat altijd een datum.")]
        [DisplayFormat(DataFormatString = "{0:dd MM yyyy}")]
        public DateTime Date { get; set; }

        [Required, Range(0.01, 9000.00, ErrorMessage = "Een boeking kost tussen de 0.01 en 9000 euro.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Een boeking kan enkel gedaan worden wanneer de gebruiker ingelogd is.")]
        public ApplicationUser User { get; set; }
    }
}
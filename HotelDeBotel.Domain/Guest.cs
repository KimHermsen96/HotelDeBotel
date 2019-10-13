using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDeBotel.Domain
{
    public class Guest : BaseEntity
    {
        [Required(ErrorMessage = "Dit veld is verplicht.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Dit veld is verplicht.")]
        [EmailAddress(ErrorMessage = "E-mailadres is niet valide.")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Dit veld is verplicht.")]
        [RegularExpression("^[0-9]{4}[A-z]{2}$", ErrorMessage = "Noteer postcode als \"1234AB\" zonder spaties" )]
        public string Zipcode { get; set; }

        [Required(ErrorMessage = "Dit veld is verplicht.")]
        [Range(1, int.MaxValue, ErrorMessage = "Huisnummer moet een positief getal zijn.")]
        public int HouseNumber { get; set; }

        [Required(ErrorMessage = "Dit veld is verplicht.")]
        [RegularExpression("^[A-z0-9]{0,3}", ErrorMessage = "Huisnummertoevoeging moet een cijfer, getal of een combinatie van beiden zijn.")]
        public string Addition { get; set; }
        public int BookingId { get; set; }
    }
}

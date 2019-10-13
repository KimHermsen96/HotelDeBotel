using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelDeBotel.Domain
{
    public class Room : BaseEntity
    {

        [Required(ErrorMessage = "Dit veld is verplicht")]
        public string Name { get; set; }

        [Required (ErrorMessage = "Dit veld is verplicht")]
        [Range(2, 5, ErrorMessage = "Selecteer een getal tussen de 2 en 5")]
        public int Size { get; set; }

        [Required(ErrorMessage = "Dit veld is verplicht")]
        [Range(0, 9999999999999999, ErrorMessage = "Vul een geldig bedrag in (Minimale bedrag is 0 euro).")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Dit veld is verplicht")]
        [Url]
        public string Image { get; set; }
    }
}
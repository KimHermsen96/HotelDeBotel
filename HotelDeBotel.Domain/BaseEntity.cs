using System.ComponentModel.DataAnnotations;

namespace HotelDeBotel.Domain
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
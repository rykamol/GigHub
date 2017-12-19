using System.ComponentModel.DataAnnotations;

namespace GigHub.Models
{
    public class Genre
    {
        public byte Id { get; set; } //255 max
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

    }
}
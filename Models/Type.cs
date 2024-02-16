using System.ComponentModel.DataAnnotations;

namespace crud_system.Models
{
    public class Type
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string  Name { get; set; }
    }
}

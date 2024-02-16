using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crud_system.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Discription { get; set; }
        
        public bool Enable { get; set; }
        public int TypeId { get; set; }
        [ForeignKey("TypeId")]

        public Type type {  get; set; }
    
    }
}

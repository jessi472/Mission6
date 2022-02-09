using System.ComponentModel.DataAnnotations;

namespace Mission6.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int CategoryId { get; set; }
        public string CategoryTitle { get; set; }
    }
}

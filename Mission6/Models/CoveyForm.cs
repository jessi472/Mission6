using System.ComponentModel.DataAnnotations;

namespace Mission6.Models
{
    public class CoveyForm
    {
        [Key]
        [Required]
        public int TaskId { get; set; }
        [Required]
        public string Task { get; set; }
        public string DueDate { get; set; }
        [Required]
        public string Quadrant { get; set; }
       
        public bool Completed { get; set; }

        //Foreign Category Key

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

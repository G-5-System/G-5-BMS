using System.ComponentModel.DataAnnotations;

namespace G_5_BMS.Models
{
    public class faqs
    {
        [Key]
        public int FId { get; set; }

        [Required(ErrorMessage = "Question is required.")]
        [StringLength(500, ErrorMessage = "Question cannot exceed 500 characters.")]
        public string Question { get; set; }

        [Required(ErrorMessage = "Answer is required.")]
        public string Answer { get; set; }
    }
}

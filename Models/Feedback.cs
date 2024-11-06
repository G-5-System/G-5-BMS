using System.ComponentModel.DataAnnotations;

namespace G_5_BMS.Models
{
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
    }
}

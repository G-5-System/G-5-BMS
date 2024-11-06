using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace G_5_BMS.Models
{
    public class FAQViewModel
    {
        public List<faqs> FAQs { get; set; } = new List<faqs>(); // Ensure it's initialized
        public List<Feedback> Feedbacks { get; set; }
    }
}

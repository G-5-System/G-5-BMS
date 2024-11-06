using System.ComponentModel.DataAnnotations;

namespace G_5_BMS.Models
{
    public class HomeContents
    {
        [Key]
        public int AnnoId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime DateTime { get; set; }
        public string Location { get; set; }
    }
}

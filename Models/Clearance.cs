using System.ComponentModel.DataAnnotations;

namespace G_5_BMS.Models
{
    public class Clearance
    {
        [Key]
        public int CLId { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Middle Name is required.")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Suffix is required.")]
        public string Suffix { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Contact Number is required.")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Email Address is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string EmailAddress { get; set; }

        public string BusinessName { get; set; }
        public string BNature { get; set; }
        public string Ownership { get; set; }
    }
}

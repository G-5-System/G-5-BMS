using System.ComponentModel.DataAnnotations;

namespace G_5_BMS.Models
{
    public class Clearance
    {
        [Key]
        public int CLId { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(50, ErrorMessage = "First Name cannot exceed 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Middle Name is required.")]
        [StringLength(50, ErrorMessage = "Middle Name cannot exceed 50 characters.")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(50, ErrorMessage = "Last Name cannot exceed 50 characters.")]
        public string LastName { get; set; }

        [StringLength(10, ErrorMessage = "Suffix cannot exceed 10 characters.")]
        public string Suffix { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        [RegularExpression("^(Male|Female|Other)$", ErrorMessage = "Gender must be 'Male', 'Female', or 'Other'.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(100, ErrorMessage = "Address cannot exceed 100 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Contact Number is required.")]
        [Phone(ErrorMessage = "Invalid Contact Number format.")]
        [RegularExpression(@"^\+?[0-9]{10,15}$", ErrorMessage = "Contact Number must be between 10 and 15 digits.")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Email Address is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string EmailAddress { get; set; }

        [StringLength(100, ErrorMessage = "Business Name cannot exceed 100 characters.")]
        public string BusinessName { get; set; }

        [StringLength(50, ErrorMessage = "Business Nature cannot exceed 50 characters.")]
        public string BusinessNature { get; set; }

        [StringLength(50, ErrorMessage = "Ownership type cannot exceed 50 characters.")]
        public string Ownership { get; set; }
    }
}

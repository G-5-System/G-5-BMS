using System;
using System.ComponentModel.DataAnnotations;

namespace G_5_BMS.Models
{
    public class Certificate
    {
        [Key]
        public int CRId { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters.")]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "Middle Name cannot be longer than 50 characters.")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(50, ErrorMessage = "Last Name cannot be longer than 50 characters.")]
        public string LastName { get; set; }

        [StringLength(10, ErrorMessage = "Suffix cannot be longer than 10 characters.")]
        public string Suffix { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        [RegularExpression("^(Male|Female|Other)$", ErrorMessage = "Gender must be 'Male', 'Female', or 'Other'.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(100, ErrorMessage = "Address cannot be longer than 100 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Contact Number is required.")]
        [Phone(ErrorMessage = "Invalid Contact Number format.")]
        [RegularExpression(@"^\+?[0-9]{10,15}$", ErrorMessage = "Contact Number must be between 10 and 15 digits.")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Email Address is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Year is required.")]
        [Range(1900, 2100, ErrorMessage = "Year must be between 1900 and 2100.")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Purpose is required.")]
        [StringLength(100, ErrorMessage = "Purpose cannot be longer than 100 characters.")]
        public string Purpose { get; set; }
    }
}

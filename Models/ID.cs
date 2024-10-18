using System;
using System.ComponentModel.DataAnnotations;

namespace G_5_BMS.Models
{
    public class ID
    {
        [Key]
        public int RId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Middle name is required.")]
        [StringLength(50, ErrorMessage = "Middle name cannot be longer than 50 characters.")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string LastName { get; set; }

        [StringLength(10, ErrorMessage = "Suffix cannot be longer than 10 characters.")]
        public string Suffix { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Civil status is required.")]
        [StringLength(20, ErrorMessage = "Civil status cannot be longer than 20 characters.")]
        public string CivilStatus { get; set; }

        [Required(ErrorMessage = "Citizenship is required.")]
        [StringLength(50, ErrorMessage = "Citizenship cannot be longer than 50 characters.")]
        public string Citizenship { get; set; }

        [Required(ErrorMessage = "Birthday is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        [Range(1, 150, ErrorMessage = "Please enter a valid age between 1 and 150.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(100, ErrorMessage = "Address cannot be longer than 100 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Province is required.")]
        [StringLength(50, ErrorMessage = "Province cannot be longer than 50 characters.")]
        public string Province { get; set; }

        [Required(ErrorMessage = "Municipality is required.")]
        [StringLength(50, ErrorMessage = "Municipality cannot be longer than 50 characters.")]
        public string Municipality { get; set; }

        [Required(ErrorMessage = "Barangay is required.")]
        [StringLength(50, ErrorMessage = "Barangay cannot be longer than 50 characters.")]
        public string Barangay { get; set; }

        [Required(ErrorMessage = "Contact number is required.")]
        [Phone(ErrorMessage = "Please enter a valid contact number.")]
        [StringLength(15, ErrorMessage = "Contact number cannot be longer than 15 characters.")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string EmailAddress { get; set; }
    }
}

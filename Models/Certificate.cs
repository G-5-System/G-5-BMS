using System;
using System.ComponentModel.DataAnnotations;

namespace G_5_BMS.Models
{
    public class Certificate
    {
        [Key]
        public int CRId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters.")]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "Middle Name cannot be longer than 50 characters.")]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Last Name cannot be longer than 50 characters.")]
        public string LastName { get; set; }

        [StringLength(10, ErrorMessage = "Suffix cannot be longer than 10 characters.")]
        public string Suffix { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Address cannot be longer than 100 characters.")]
        public string Address { get; set; }

        [Required]
        [Phone]
        public string ContactNumber { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string EmailAddress { get; set; }

        [Required]
        [Range(1900, 2100, ErrorMessage = "Year must be between 1900 and 2100.")]
        public int Year { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Purpose cannot be longer than 100 characters.")]
        public string Purpose { get; set; }
    }
}

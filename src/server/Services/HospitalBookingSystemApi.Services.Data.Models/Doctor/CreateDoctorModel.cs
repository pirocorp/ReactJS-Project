namespace HospitalBookingSystemApi.Services.Data.Models.Doctor
{
    using System.ComponentModel.DataAnnotations;

    public class CreateDoctorModel
    {
        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [EmailAddress]
        [StringLength(255)]
        [DataType(DataType.EmailAddress)]
        public string WorkEmail { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(255)]
        public string WorkPhone { get; set; }

        [StringLength(65535)]
        public string ImageUrl { get; set; }

        [Required]
        [MinLength(3)]
        public string Username { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "The Password field must be a minimum of 6 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

namespace HospitalBookingSystemApi.Services.Data.Models.Doctor
{
    using System.ComponentModel.DataAnnotations;

    public class UpdateDoctorModel
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
    }
}

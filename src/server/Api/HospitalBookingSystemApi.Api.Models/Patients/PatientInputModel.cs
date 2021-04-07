namespace HospitalBookingSystemApi.Api.Models.Patients
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using HospitalBookingSystemApi.Services.Data.Models.Patient;
    using HospitalBookingSystemApi.Services.Mapping;
    using Microsoft.AspNetCore.Http;

    public class PatientInputModel : IMapTo<ServicePatientModel>
    {
        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [Required]
        [StringLength(255)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        [Required]
        [StringLength(255)]
        public string City { get; set; }

        [Required]
        [StringLength(255)]
        public string Phone { get; set; }

        [IgnoreMap]
        public IFormFile Image { get; set; }

        [Required]
        [StringLength(255)]
        public string SSN { get; set; }
    }
}

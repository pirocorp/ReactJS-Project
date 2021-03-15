namespace HospitalBookingSystemApi.Api.Models.Users
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using HospitalBookingSystemApi.Data.Models;

    public class UserRegisterModel
    {
        [Required]
        [MinLength(3)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "The Password field must be a minimum of 6 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

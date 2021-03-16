namespace HospitalBookingSystemApi.Services.Data.Models.Users
{
    using System.ComponentModel.DataAnnotations;

    public class UserLoginModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

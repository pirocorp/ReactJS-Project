namespace HospitalBookingSystemApi.Services.Data.Models.Appointment
{
    using System.ComponentModel.DataAnnotations;

    public class CreateAppointment
    {
        [Required]
        public string DoctorId { get; set; }

        [Required]
        public string SlotId { get; set; }

        [Required]
        public string ShiftId { get; set; }
    }
}

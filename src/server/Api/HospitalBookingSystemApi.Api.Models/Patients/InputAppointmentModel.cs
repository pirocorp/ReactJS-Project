namespace HospitalBookingSystemApi.Api.Models.Patients
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class InputAppointmentModel
    {
        [Required]
        public string DoctorId { get; set; }

        [Required]
        public string SlotId { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}

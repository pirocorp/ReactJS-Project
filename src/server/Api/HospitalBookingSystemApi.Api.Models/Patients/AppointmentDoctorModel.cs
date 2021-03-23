namespace HospitalBookingSystemApi.Api.Models.Patients
{
    using System.ComponentModel.DataAnnotations;

    public class AppointmentDoctorModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string WorkEmail { get; set; }

        public string WorkPhone { get; set; }
    }
}

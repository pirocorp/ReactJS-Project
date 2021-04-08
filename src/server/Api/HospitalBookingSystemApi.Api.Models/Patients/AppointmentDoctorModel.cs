namespace HospitalBookingSystemApi.Api.Models.Patients
{
    using HospitalBookingSystemApi.Data.Models;
    using HospitalBookingSystemApi.Services.Mapping;

    public class AppointmentDoctorModel : IMapFrom<Doctor>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string WorkEmail { get; set; }

        public string WorkPhone { get; set; }
    }
}

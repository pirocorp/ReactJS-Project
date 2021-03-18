namespace HospitalBookingSystemApi.Api.Models.Doctors
{
    using HospitalBookingSystemApi.Data.Models;
    using HospitalBookingSystemApi.Services.Mapping;

    public class AppointmentPatient : IMapFrom<Patient>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string SSN { get; set; }
    }
}

namespace HospitalBookingSystemApi.Api.Models.Patients
{
    using System.Collections.Generic;

    using HospitalBookingSystemApi.Data.Models;
    using HospitalBookingSystemApi.Services.Mapping;

    public class PatientModel : IMapFrom<Patient>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Phone { get; set; }

        public string SSN { get; set; }

        public List<PatientAppointmentListingModel> Appointments { get; set; }
    }
}

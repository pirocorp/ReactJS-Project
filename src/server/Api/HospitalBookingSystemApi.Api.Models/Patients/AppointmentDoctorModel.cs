namespace HospitalBookingSystemApi.Api.Models.Patients
{
    using System.Collections.Generic;

    using HospitalBookingSystemApi.Api.Models.Doctors;
    using HospitalBookingSystemApi.Data.Models;
    using HospitalBookingSystemApi.Services.Mapping;

    public class AppointmentDoctorModel : IMapFrom<Doctor>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string WorkEmail { get; set; }

        public string WorkPhone { get; set; }

        public string ImageUrl { get; set; }

        public IEnumerable<SpecializationListingModel> Specializations { get; set; }
    }
}

namespace HospitalBookingSystemApi.Api.Models.Patients
{
    using HospitalBookingSystemApi.Data.Models;
    using HospitalBookingSystemApi.Services.Mapping;

    public class AppointmentStatusModel : IMapFrom<AppointmentStatus>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}

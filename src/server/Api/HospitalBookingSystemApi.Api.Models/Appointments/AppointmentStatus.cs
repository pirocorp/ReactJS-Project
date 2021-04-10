namespace HospitalBookingSystemApi.Api.Models.Appointments
{
    using HospitalBookingSystemApi.Data.Models;
    using HospitalBookingSystemApi.Services.Mapping;

    public class AppointmentStatus : IMapFrom<Appointment>
    {
        public string StatusName { get; set; }
    }
}

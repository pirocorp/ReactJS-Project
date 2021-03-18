namespace HospitalBookingSystemApi.Api.Models.Doctors
{
    using HospitalBookingSystemApi.Data.Models;
    using HospitalBookingSystemApi.Services.Mapping;

    public class AppointmentSlot : IMapFrom<Slot>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}

namespace HospitalBookingSystemApi.Api.Models.Doctors
{
    using AutoMapper;
    using HospitalBookingSystemApi.Data.Models;
    using HospitalBookingSystemApi.Services.Mapping;

    public class AppointmentListingModel : IMapFrom<Appointment>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public AppointmentPatient Patient { get; set; }

        public AppointmentSlot Slot { get; set; }

        public AppointmentShift Shift { get; set; }

        public string Status { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<Appointment, AppointmentListingModel>()
                .ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status.Name));
        }
    }
}

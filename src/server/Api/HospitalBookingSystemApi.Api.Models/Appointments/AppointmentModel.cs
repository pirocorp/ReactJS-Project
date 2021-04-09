namespace HospitalBookingSystemApi.Api.Models.Appointments
{
    using System;

    using AutoMapper;
    using HospitalBookingSystemApi.Data.Models;
    using HospitalBookingSystemApi.Services.Mapping;

    public class AppointmentModel : IMapFrom<Appointment>, IHaveCustomMappings
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Date { get; set; }

        public string Slot { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<Appointment, AppointmentModel>()
                .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.Doctor.FirstName))
                .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.Doctor.LastName))
                .ForMember(d => d.Date, opt => opt.MapFrom(s => s.Shift.Date))
                .ForMember(d => d.Slot, opt => opt.MapFrom(s => s.Slot.Name));
        }
    }
}

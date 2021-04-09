namespace HospitalBookingSystemApi.Api.Models.Patients
{
    using System;

    using AutoMapper;
    using HospitalBookingSystemApi.Data.Models;
    using HospitalBookingSystemApi.Services.Mapping;

    public class AppointmentDetailsModel : IMapFrom<Appointment>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public AppointmentDoctorModel Doctor { get; set; }

        public DateTime Date { get; set; }

        public string Slot { get; set; }

        public string Notes { get; set; }

        public AppointmentStatusModel Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<Appointment, AppointmentDetailsModel>()
                .ForMember(d => d.Date, opt => opt.MapFrom(s => s.Shift.Date))
                .ForMember(d => d.Slot, opt => opt.MapFrom(s => s.Slot.Name));
        }
    }
}

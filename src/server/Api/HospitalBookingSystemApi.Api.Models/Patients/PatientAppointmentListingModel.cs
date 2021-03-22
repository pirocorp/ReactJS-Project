namespace HospitalBookingSystemApi.Api.Models.Patients
{
    using System;

    using AutoMapper;
    using HospitalBookingSystemApi.Data.Models;
    using HospitalBookingSystemApi.Services.Mapping;

    public class PatientAppointmentListingModel : IMapFrom<Appointment>, IHaveCustomMappings
    {
        public PatientAppointmentDoctorModel Doctor { get; set; }

        public DateTime Date { get; set; }

        public string Slot { get; set; }

        public string Status { get; set; }

        public string Notes { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<Appointment, PatientAppointmentListingModel>()
                .ForMember(d => d.Date, opt => opt.MapFrom(s => s.Shift.Date))
                .ForMember(d => d.Slot, opt => opt.MapFrom(s => s.Slot.Name))
                .ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status.Name));
        }
    }
}

namespace HospitalBookingSystemApi.Api.Models.Doctors
{
    using System;

    using HospitalBookingSystemApi.Data.Models;
    using HospitalBookingSystemApi.Services.Mapping;

    public class AppointmentShift : IMapFrom<Shift>
    {
        public string Id { get; set; }

        public DateTime Date { get; set; }
    }
}

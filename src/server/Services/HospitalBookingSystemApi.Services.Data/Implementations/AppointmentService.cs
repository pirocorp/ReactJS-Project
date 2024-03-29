﻿namespace HospitalBookingSystemApi.Services.Data.Implementations
{
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    using HospitalBookingSystemApi.Common;
    using HospitalBookingSystemApi.Data;
    using HospitalBookingSystemApi.Data.Models;
    using HospitalBookingSystemApi.Services.Data.Models.Appointment;
    using HospitalBookingSystemApi.Services.Mapping;

    using Microsoft.EntityFrameworkCore;

    public class AppointmentService : IAppointmentService
    {
        private readonly HospitalBookingSystemDbContext dbContext;
        private readonly IAppointmentStatusesService appointmentStatusesService;

        public AppointmentService(
            HospitalBookingSystemDbContext dbContext,
            IAppointmentStatusesService appointmentStatusesService)
        {
            this.dbContext = dbContext;
            this.appointmentStatusesService = appointmentStatusesService;
        }

        public async Task<bool> ExistsAsync(string id)
            => await this.dbContext.Appointments.AnyAsync(a => a.Id.Equals(id));

        public async Task<T> GetAsync<T>(string id)
            => await this.dbContext.Appointments
                .Where(a => a.Id.Equals(id))
                .To<T>()
                .FirstOrDefaultAsync();

        public async Task CancelAppointmentAsync(string appointmentId)
        {
            var appointment = await this.dbContext.Appointments.FindAsync(appointmentId);

            appointment.StatusId = await this.appointmentStatusesService.GetStatusIdAsync(GlobalConstants.CancelAppointmentStatus);
            this.dbContext.Attach(appointment);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<string> CreateAsync(CreateAppointment model, string patientId)
        {
            var appointment = new Appointment()
            {
                PatientId = patientId,
                DoctorId = model.DoctorId,
                ShiftId = model.ShiftId,
                SlotId = model.SlotId,
                StatusId = await this.appointmentStatusesService.GetStatusIdAsync(GlobalConstants.DefaultAppointmentStatus),
            };

            await this.dbContext.Appointments.AddAsync(appointment);
            await this.dbContext.SaveChangesAsync();

            return appointment.Id;
        }

        public async Task ChangeAppointmentStatusAsync(string appointmentId, string statusName)
        {
            var appointment = await this.dbContext.Appointments.FindAsync(appointmentId);
            var statusId = await this.appointmentStatusesService.GetStatusIdAsync(statusName);

            appointment.StatusId = statusId;
            this.dbContext.Attach(appointment);
            await this.dbContext.SaveChangesAsync();
        }
    }
}

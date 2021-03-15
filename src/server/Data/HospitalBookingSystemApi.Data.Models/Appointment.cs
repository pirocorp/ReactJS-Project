namespace HospitalBookingSystemApi.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using HospitalBookingSystemApi.Data.Common.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class Appointment : BaseDeletableModel<string>, IEntityTypeConfiguration<Appointment>
    {
        public Appointment()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }

        [Required]
        public string PatientId { get; set; }

        public virtual Patient Patient { get; set; }

        [Required]
        public string SlotId { get; set; }

        public virtual Slot Slot { get; set; }

        [Required]
        public string ShiftId { get; set; }

        public virtual Shift Shift { get; set; }

        [Required]
        public string StatusId { get; set; }

        public virtual AppointmentStatus Status { get; set; }

        public string Notes { get; set; }

        public void Configure(EntityTypeBuilder<Appointment> appointment)
        {
            appointment
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            appointment
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            appointment
                .HasOne(a => a.Slot)
                .WithMany()
                .HasForeignKey(a => a.SlotId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            appointment
                .HasOne(a => a.Shift)
                .WithMany(s => s.Appointments)
                .HasForeignKey(a => a.ShiftId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            appointment
                .HasOne(a => a.Status)
                .WithMany(s => s.Appointments)
                .HasForeignKey(a => a.StatusId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

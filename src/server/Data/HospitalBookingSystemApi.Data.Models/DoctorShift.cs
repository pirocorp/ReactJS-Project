namespace HospitalBookingSystemApi.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class DoctorShift : IEntityTypeConfiguration<DoctorShift>
    {
        [Required]
        public string DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }

        [Required]
        public string ShiftId { get; set; }

        public virtual Shift Shift { get; set; }

        public void Configure(EntityTypeBuilder<DoctorShift> doctorShift)
        {
            doctorShift
                .HasKey(key => new { key.DoctorId, key.ShiftId });

            doctorShift
                .HasOne(ds => ds.Doctor)
                .WithMany(d => d.Shifts)
                .HasForeignKey(ds => ds.DoctorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            doctorShift
                .HasOne(ds => ds.Shift)
                .WithMany(s => s.Doctors)
                .HasForeignKey(ds => ds.ShiftId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

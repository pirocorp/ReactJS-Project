// ReSharper disable ClassNeverInstantiated.Global
namespace HospitalBookingSystemApi.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class DoctorSpecialization : IEntityTypeConfiguration<DoctorSpecialization>
    {
        [Required]
        public string DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }

        [Required]
        public string SpecializationId { get; set; }

        public virtual Specialization Specialization { get; set; }

        public void Configure(EntityTypeBuilder<DoctorSpecialization> doctorSpecialization)
        {
            doctorSpecialization
                .HasKey(key => new { key.DoctorId, key.SpecializationId });

            doctorSpecialization
                .HasOne(ds => ds.Doctor)
                .WithMany(d => d.Specializations)
                .HasForeignKey(ds => ds.DoctorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            doctorSpecialization
                .HasOne(ds => ds.Specialization)
                .WithMany(s => s.Doctors)
                .HasForeignKey(s => s.SpecializationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

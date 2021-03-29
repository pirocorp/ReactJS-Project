namespace HospitalBookingSystemApi.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class Like : IEntityTypeConfiguration<Like>
    {
        [Required]
        public string DoctorId { get; set; }

        public Doctor Doctor { get; set; }

        [Required]
        public string PatientId { get; set; }

        public Patient Patient { get; set; }

        public void Configure(EntityTypeBuilder<Like> like)
        {
            like.HasKey(l => new { l.DoctorId, l.PatientId });

            like
                .HasOne(l => l.Doctor)
                .WithMany(d => d.Likes)
                .HasForeignKey(l => l.DoctorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            like
                .HasOne(l => l.Patient)
                .WithMany(p => p.Likes)
                .HasForeignKey(l => l.PatientId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

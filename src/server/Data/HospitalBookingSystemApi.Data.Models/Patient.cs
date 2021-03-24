// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable VirtualMemberCallInConstructor
namespace HospitalBookingSystemApi.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using HospitalBookingSystemApi.Data.Common.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class Patient : BaseDeletableModel<string>, IEntityTypeConfiguration<Patient>
    {
        public Patient()
        {
            this.Id = Guid.NewGuid().ToString();

            this.Appointments = new HashSet<Appointment>();
        }

        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [Required]
        [StringLength(255)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        [Required]
        [StringLength(255)]
        public string City { get; set; }

        [Required]
        [StringLength(255)]
        public string Phone { get; set; }

        [Required]
        [StringLength(255)]
        public string SSN { get; set; }

        [StringLength(65535)]
        public string ImageUrl { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }

        public void Configure(EntityTypeBuilder<Patient> patient)
        {
            patient
                .HasOne(p => p.User)
                .WithOne(u => u.Patients)
                .HasForeignKey<Patient>(p => p.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            patient
                .HasIndex(p => p.UserId)
                .IsUnique();
        }
    }
}

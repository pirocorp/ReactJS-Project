// ReSharper disable VirtualMemberCallInConstructor
// ReSharper disable ClassNeverInstantiated.Global
namespace HospitalBookingSystemApi.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using HospitalBookingSystemApi.Data.Common.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class Doctor : BaseDeletableModel<string>, IEntityTypeConfiguration<Doctor>
    {
        public Doctor()
        {
            this.Id = Guid.NewGuid().ToString();

            this.Specializations = new HashSet<DoctorSpecialization>();
            this.Shifts = new HashSet<DoctorShift>();
            this.Appointments = new HashSet<Appointment>();
        }

        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [StringLength(255)]
        public string WorkEmail { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(255)]
        public string WorkPhone { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<DoctorSpecialization> Specializations { get; set; }

        public virtual ICollection<DoctorShift> Shifts { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }

        public void Configure(EntityTypeBuilder<Doctor> doctor)
        {
            doctor
                .HasOne(d => d.User)
                .WithOne(u => u.Doctor)
                .HasForeignKey<Doctor>(d => d.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            doctor
                .HasIndex(d => d.UserId)
                .IsUnique();
        }
    }
}

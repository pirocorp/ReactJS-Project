// ReSharper disable VirtualMemberCallInConstructor
// ReSharper disable ClassNeverInstantiated.Global
namespace HospitalBookingSystemApi.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using HospitalBookingSystemApi.Data.Common.Models;

    public class Doctor : BaseDeletableModel<string>
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

        public virtual ICollection<DoctorSpecialization> Specializations { get; set; }

        public virtual ICollection<DoctorShift> Shifts { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}

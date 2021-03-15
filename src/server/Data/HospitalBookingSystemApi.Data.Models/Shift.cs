// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable VirtualMemberCallInConstructor
namespace HospitalBookingSystemApi.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using HospitalBookingSystemApi.Data.Common.Models;

    public class Shift : BaseDeletableModel<string>
    {
        public Shift()
        {
            this.Id = Guid.NewGuid().ToString();

            this.Doctors = new HashSet<DoctorShift>();
            this.Appointments = new HashSet<Appointment>();
        }

        [Required]
        public DateTime Date { get; set; }

        public virtual ICollection<DoctorShift> Doctors { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}

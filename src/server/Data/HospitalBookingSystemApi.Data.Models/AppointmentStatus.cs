// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable VirtualMemberCallInConstructor
namespace HospitalBookingSystemApi.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using HospitalBookingSystemApi.Data.Common.Models;

    public class AppointmentStatus : BaseDeletableModel<string>
    {
        public AppointmentStatus()
        {
            this.Id = Guid.NewGuid().ToString();

            this.Appointments = new HashSet<Appointment>();
        }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}

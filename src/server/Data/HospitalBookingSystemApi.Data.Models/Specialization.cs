﻿// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable VirtualMemberCallInConstructor
namespace HospitalBookingSystemApi.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using HospitalBookingSystemApi.Data.Common.Models;

    public class Specialization : BaseDeletableModel<string>
    {
        public Specialization()
        {
            this.Id = Guid.NewGuid().ToString();

            this.Doctors = new HashSet<DoctorSpecialization>();
        }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public virtual ICollection<DoctorSpecialization> Doctors { get; set; }
    }
}
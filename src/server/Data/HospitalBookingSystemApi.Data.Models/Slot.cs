// ReSharper disable ClassNeverInstantiated.Global
namespace HospitalBookingSystemApi.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using HospitalBookingSystemApi.Data.Common.Models;

    public class Slot : BaseDeletableModel<string>
    {
        public Slot()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(8, 18)]
        public int StartHour { get; set; }

        [Required]
        [Range(0, 59)]
        public int StartMin { get; set; }

        [Required]
        [Range(8, 19)]
        public int EndHour { get; set; }

        [Required]
        [Range(0, 59)]
        public int EndMin { get; set; }
    }
}

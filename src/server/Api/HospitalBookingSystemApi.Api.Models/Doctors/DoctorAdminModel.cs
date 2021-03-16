// ReSharper disable ClassNeverInstantiated.Global
namespace HospitalBookingSystemApi.Api.Models.Doctors
{
    using System;

    using AutoMapper;
    using HospitalBookingSystemApi.Data.Models;
    using HospitalBookingSystemApi.Services.Mapping;

    public class DoctorAdminModel : IMapFrom<Doctor>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string WorkEmail { get; set; }

        public string WorkPhone { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<Doctor, DoctorModel>()
                .ForMember(d => d.Specializations, opt => opt.MapFrom(s => s.Specializations));
        }
    }
}

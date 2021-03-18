// ReSharper disable ClassNeverInstantiated.Global
namespace HospitalBookingSystemApi.Api.Models.Doctors
{
    using System;

    using AutoMapper;
    using HospitalBookingSystemApi.Data.Models;
    using HospitalBookingSystemApi.Services.Mapping;

    public class DoctorAdminModel : DoctorModel, IMapFrom<Doctor>, IHaveCustomMappings
    {
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public override void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<Doctor, DoctorModel>()
                .ForMember(d => d.Specializations, opt => opt.MapFrom(s => s.Specializations));
        }
    }
}

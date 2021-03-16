namespace HospitalBookingSystemApi.Api.Models.Doctors
{
    using System.Collections.Generic;

    using AutoMapper;
    using HospitalBookingSystemApi.Data.Models;
    using HospitalBookingSystemApi.Services.Mapping;

    public class DoctorModel : IMapFrom<Doctor>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string WorkEmail { get; set; }

        public string WorkPhone { get; set; }

        public List<SpecializationListingModel> Specializations { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<Doctor, DoctorModel>()
                .ForMember(d => d.Specializations, opt => opt.MapFrom(s => s.Specializations));
        }
    }
}

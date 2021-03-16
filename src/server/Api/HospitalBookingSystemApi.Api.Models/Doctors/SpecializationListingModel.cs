namespace HospitalBookingSystemApi.Api.Models.Doctors
{
    using AutoMapper;

    using HospitalBookingSystemApi.Data.Models;
    using HospitalBookingSystemApi.Services.Mapping;

    public class SpecializationListingModel : IMapFrom<DoctorSpecialization>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<DoctorSpecialization, SpecializationListingModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.SpecializationId))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Specialization.Name));
        }
    }
}

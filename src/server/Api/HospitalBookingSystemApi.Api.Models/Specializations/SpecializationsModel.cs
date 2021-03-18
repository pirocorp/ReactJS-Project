namespace HospitalBookingSystemApi.Api.Models.Specializations
{
    using HospitalBookingSystemApi.Data.Models;
    using HospitalBookingSystemApi.Services.Mapping;

    public class SpecializationsModel : IMapFrom<Specialization>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}

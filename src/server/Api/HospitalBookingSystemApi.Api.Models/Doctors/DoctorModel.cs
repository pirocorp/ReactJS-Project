namespace HospitalBookingSystemApi.Api.Models.Doctors
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json.Serialization;

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

        public string Education { get; set; }

        public string ImageUrl { get; set; }

        public int RatingsCount { get; set; }

        [JsonIgnore]
        public int RatingsSum { get; set; }

        [IgnoreMap]
        public double Rating => this.RatingsCount > 0
            ? this.RatingsSum / (double) this.RatingsCount
            : 0;

        public List<SpecializationListingModel> Specializations { get; set; }

        public virtual void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<Doctor, DoctorModel>()
                .ForMember(d => d.Specializations, opt => opt.MapFrom(s => s.Specializations))
                .ForMember(d => d.RatingsCount, opt => opt.MapFrom(s => s.Likes.Count))
                .ForMember(d => d.RatingsCount, opt => opt.MapFrom(s => s.Likes.Sum(x => x.Rating)));
        }
    }
}

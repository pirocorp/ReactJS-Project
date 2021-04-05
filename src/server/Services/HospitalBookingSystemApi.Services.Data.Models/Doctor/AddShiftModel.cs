namespace HospitalBookingSystemApi.Services.Data.Models.Doctor
{
    using HospitalBookingSystemApi.Data.Models;
    using HospitalBookingSystemApi.Services.Mapping;

    public class AddShiftModel : IMapFrom<Shift>
    {
        public string Id { get; set; }
    }
}

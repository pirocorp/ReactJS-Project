namespace HospitalBookingSystemApi.Api.Models.Slots
{
    using HospitalBookingSystemApi.Data.Models;
    using HospitalBookingSystemApi.Services.Mapping;

    public class SlotListingModel : IMapFrom<Slot>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Order { get; set; }

        public int StartHour { get; set; }

        public int StartMin { get; set; }

        public int EndHour { get; set; }

        public int EndMin { get; set; }
    }
}

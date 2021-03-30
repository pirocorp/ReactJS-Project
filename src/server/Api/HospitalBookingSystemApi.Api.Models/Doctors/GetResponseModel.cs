namespace HospitalBookingSystemApi.Api.Models.Doctors
{
    using System.Collections.Generic;

    public class GetResponseModel<T>
    {
        public IEnumerable<T> Results { get; set; }

        public int Total { get; set; }
    }
}

namespace HospitalBookingSystemApi.Common
{
    public static class GlobalConstants
    {
        public const string SystemName = "Hospital Booking System Api";

        public const string CancelAppointmentStatus = "Canceled";

        public const string CloudinaryResourceBaseAddress = "https://res.cloudinary.com";

        public const int PageSize = 10;

        public const string DefaultAppointmentStatus = "Pending";

        public const string IgnoredAppointments = "Canceled";

        public static class RolesNames
        {
            public const string Administrator = "Administrator";

            public const string Doctor = "Doctor";

            public const string Patient = "Patient";
        }
    }
}

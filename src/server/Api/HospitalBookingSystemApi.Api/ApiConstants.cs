namespace HospitalBookingSystemApi.Api
{
    public static class ApiConstants
    {
        public const string WithId = "{id}";

        public static class Messages
        {
            public const string InvalidCredentials = "Username or password is incorrect.";
        }

        public static class Errors
        {
            public const string DoctorCreation = "Doctor Creation";
            public const string UsernameOrEmailInUse = "Username or email is already taken.";
        }
    }
}

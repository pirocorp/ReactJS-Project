namespace HospitalBookingSystemApi.Api
{
    public static class ApiConstants
    {
        public const string WithId = "{id}";

        public static class DoctorsEndpoints
        {
            public const string Specializations = "/specializations";

            public const string Shifts = "/shifts";

            public const string Appointments = "/appointments";
        }

        public static class Messages
        {
            public const string InvalidCredentials = "Username or password is incorrect.";
        }

        public static class Errors
        {
            public const string DoctorCreation = "Doctor Creation";
            public const string DoctorUpdate = "Doctor Update";
            public const string InsufficientPermission = "Insufficient Permission to perform this action.";
            public const string UsernameOrEmailInUse = "Username or email is already taken.";
        }
    }
}

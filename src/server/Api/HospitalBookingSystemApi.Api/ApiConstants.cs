namespace HospitalBookingSystemApi.Api
{
    using HospitalBookingSystemApi.Api.Models;

    public static class ApiConstants
    {
        public const string WithId = "{id}";

        public static class Parameters
        {
            public const string DoctorId = "{doctorId}";

            public const string SpecializationId = "{specializationId}";

            public const string ShiftId = "{shiftId}";
        }

        public static class DoctorsEndpoints
        {
            public const string Specializations = "/specializations";

            public const string Shifts = "/shifts";

            public const string Appointments = "/appointments";

            public const string UnDelete = "/undelete";
        }

        public static class Messages
        {
            public const string InvalidCredentials = "Username or password is incorrect.";
        }

        public static class Errors
        {
            public static readonly ApiErrorModel DoctorUpdateInsufficientPermission = new ()
            {
                Code = ErrorsMessages.DoctorUpdate,
                Description = ErrorsMessages.InsufficientPermission,
            };

            public static readonly ApiErrorModel DoctorUpdateSpecializationNotFound = new ()
            {
                Code = ErrorsMessages.DoctorUpdate,
                Description = ErrorsMessages.SpecializationNotFound,
            };

            public static readonly ApiErrorModel DoctorUpdateShiftNotFound = new ()
            {
                Code = ErrorsMessages.DoctorUpdate,
                Description = ErrorsMessages.ShiftNotFound,
            };

            public static readonly ApiErrorModel DoctorCreationUsernameOrEmailInUse = new ()
            {
                Code = ErrorsMessages.DoctorCreation,
                Description = ErrorsMessages.UsernameOrEmailInUse,
            };

            public static readonly ApiErrorModel RegisterUsernameOrEmailInUse = new ()
            {
                Code = ErrorsMessages.Register,
                Description = ErrorsMessages.UsernameOrEmailInUse,
            };
        }

        private static class ErrorsMessages
        {
            public const string DoctorCreation = "Doctor Creation";
            public const string DoctorUpdate = "Doctor Update";
            public const string Register = "Register";

            public const string InsufficientPermission = "Insufficient Permission to perform this action.";
            public const string UsernameOrEmailInUse = "Username or email is already taken.";
            public const string SpecializationNotFound = "Specialization not found.";
            public const string ShiftNotFound = "Shift not found.";
        }
    }
}

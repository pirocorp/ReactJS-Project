namespace HospitalBookingSystemApi.Api
{
    using HospitalBookingSystemApi.Api.Models;

    public static class ApiConstants
    {
        public const string WithId = "{id}";

        public static class Parameters
        {
            public const string AppointmentId = "{appointmentId}";

            public const string DoctorId = "{doctorId}";

            public const string SpecializationId = "{specializationId}";

            public const string PatientId = "{patientId}";

            public const string ShiftId = "{shiftId}";
        }

        public static class PatientsEndpoints
        {
            public const string UnDelete = "/undelete";

            public const string Appointments = "/appointments";

            public const string CancelAppointment = "/cancel";
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

            public static readonly ApiErrorModel UserAlreadyHavePatientProfile = new ()
            {
                Code = ErrorsMessages.PatientProfileCreation,
                Description = ErrorsMessages.UserAlreadyHavePatientProfile,
            };

            public static readonly ApiErrorModel UserDoNotHavePatientProfile = new ()
            {
                Code = ErrorsMessages.PatientProfileUpdate,
                Description = ErrorsMessages.UserDoNotHavePatientProfile,
            };

            public static readonly ApiErrorModel PatientInsufficientPermission = new ()
            {
                Code = ErrorsMessages.Patient,
                Description = ErrorsMessages.InsufficientPermission,
            };

            public static readonly ApiErrorModel PageError = new ()
            {
                Code = ErrorsMessages.Page,
                Description = ErrorsMessages.InvalidPageNumber,
            };
        }

        private static class ErrorsMessages
        {
            public const string DoctorCreation = "Doctor Creation";
            public const string DoctorUpdate = "Doctor Update";
            public const string PatientProfileCreation = "Patient Profile Creation";
            public const string PatientProfileUpdate = "Patient Profile Update";
            public const string PatientUpdate = "Patient Update";
            public const string Patient = "Patient";
            public const string Register = "Register";
            public const string Page = "Page";

            public const string InsufficientPermission = "Insufficient Permission to perform this action.";
            public const string UsernameOrEmailInUse = "Username or email is already taken.";
            public const string SpecializationNotFound = "Specialization not found.";
            public const string ShiftNotFound = "Shift not found.";
            public const string UserAlreadyHavePatientProfile = "User Already Have Patient Profile";
            public const string UserDoNotHavePatientProfile = "User Do Not Have Patient Profile";
            public const string InvalidPageNumber = "Invalid Page Number";
        }
    }
}

const routes = {
    patients: [
        { path: "/patients/search", title: "Search for Doctors" },
        { path: "/login", title: "Login" },
        { path: "/patients/register", title: "Register" },
        { path: "/patients/booking", title: "Booking" },
        { path: "/patients/patient-dashboard", title: "Patient Dashboard" }
    ],
    doctors: [
        { path: "/doctors/appointments", title: "Appointments" },
        { path: "/login", title: "Login" },
        { path: "/doctors/doctor-dashboard", title: "Doctor Dashboard" }
    ],
    admin: [
        
    ]
};

export { routes };
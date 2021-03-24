import { Link } from 'react-router-dom';

import './MenuNavigation.css';

const MenuNavigation = () => {
    const currentPath = window.location.pathname;

    const setClassName = (path) => {
        if (currentPath.startsWith(path) && path.length > 1) {
            return 'active';
        } else if (currentPath === path){
            return 'active';
        }

        return '';
    }

    return(
        <ul className="main-nav">
            <li className={setClassName('/')}>
                <Link to="/">Home</Link>
            </li>
            <li className={setClassName('/doctors') + " has-submenu"}>
                <Link to="/doctors">Doctors <i className="fas fa-chevron-down"></i></Link>
                <ul className="submenu">
                    <li><Link to="/doctors/doctor-dashboard.html">Doctor Dashboard</Link></li>
                    <li><Link to="/doctors/appointments.html">Appointments</Link></li>
                    <li><Link to="/doctors/schedule-timings.html">Schedule Timing</Link></li>
                    <li><Link to="/doctors/my-patients.html">Patients List</Link></li>
                    <li><Link to="/doctors/patient-profile.html">Patients Profile</Link></li>
                    <li><Link to="/doctors/chat-doctor.html">Chat</Link></li>
                    <li><Link to="/doctors/invoices.html">Invoices</Link></li>
                    <li><Link to="/doctors/doctor-profile-settings.html">Profile Settings</Link></li>
                    <li><Link to="/doctors/reviews.html">Reviews</Link></li>
                    <li><Link to="/doctors/doctor-register.html">Doctor Register</Link></li>
                </ul>
            </li>
            <li className={setClassName('/patients') + " has-submenu"}>
                <Link to="/patients">Patients <i className="fas fa-chevron-down"></i></Link>
                <ul className="submenu">
                    <li><Link to="/patients/search.html">Search Doctor</Link></li>
                    <li><Link to="/patients/doctor-profile.html">Doctor Profile</Link></li>
                    <li><Link to="/patients/booking.html">Booking</Link></li>
                    <li><Link to="/patients/checkout.html">Checkout</Link></li>
                    <li><Link to="/patients/booking-success.html">Booking Success</Link></li>
                    <li><Link to="/patients/patient-dashboard.html">Patient Dashboard</Link></li>
                    <li><Link to="/patients/favourites.html">Favourites</Link></li>
                    <li><Link to="/patients/chat.html">Chat</Link></li>
                    <li><Link to="/patients/profile-settings.html">Profile Settings</Link></li>
                    <li><Link to="/patients/change-password.html">Change Password</Link></li>
                </ul>
            </li>
            <li className={setClassName('/pages') + " has-submenu"}>
                <Link to="/pages">Pages <i className="fas fa-chevron-down"></i></Link>
                <ul className="submenu">
                    <li><Link to="/pages/voice-call.html">Voice Call</Link></li>
                    <li><Link to="/pages/video-call.html">Video Call</Link></li>
                    <li><Link to="/pages/search.html">Search Doctors</Link></li>
                    <li><Link to="/pages/calendar.html">Calendar</Link></li>
                    <li><Link to="/pages/components.html">Components</Link></li>
                    <li className="has-submenu">
                        <Link to="/pages/invoices.html">Invoices</Link>
                        <ul className="submenu">
                            <li><Link to="/pages/invoices.html">Invoices</Link></li>
                            <li><Link to="/pages/invoice-view.html">Invoice View</Link></li>
                        </ul>
                    </li>
                    <li><Link to="/pages/blank-page.html">Starter Page</Link></li>
                    <li><Link to="/pages/login.html">Login</Link></li>
                    <li><Link to="/pages/register.html">Register</Link></li>
                    <li><Link to="/pages/forgot-password.html">Forgot Password</Link></li>
                </ul>
            </li>
            <li className={setClassName('/admin')}>
                <Link to="/admin">Admin</Link>
            </li>
            <li className="login-link">
                <Link to="/login">Login / Signup</Link>
            </li>
        </ul>
    );
}

export default MenuNavigation;
import FooterWidget from './FooterWidget';
import FooterAbout from './FooterAbout';
import FooterContact from './FooterContact';
import FooterMenu from './FooterMenu';

import './FooterTop.css';

const FooterTop = () => {
    return (
        <div className="footer-top">
            <div className="container-fluid">
                <div className="row">
                    <FooterWidget>
                        <FooterAbout />
                    </FooterWidget>
                    <FooterWidget>
                        <FooterMenu title="For Patients" links={[
                            { path: "/patients/search", title: "Search for Doctors" },
                            { path: "/patients/login", title: "Login" },
                            { path: "/patients/register", title: "Register" },
                            { path: "/patients/booking", title: "Booking" },
                            { path: "/patients/patient-dashboard", title: "Patient Dashboard" }]}
                        />
                    </FooterWidget>
                    <FooterWidget>
                        <FooterMenu title="For Doctors" links={[
                            { path: "/doctors/appointments", title: "Appointments" },
                            { path: "/doctors/chat", title: "Chat" },
                            { path: "/doctors/login", title: "Login" },
                            { path: "/doctors/doctor-register", title: "Register" },
                            { path: "/doctors/doctor-dashboard", title: "Doctor Dashboard" }]}
                        />
                    </FooterWidget>
                    <FooterWidget>
                        <FooterContact />
                    </FooterWidget>
                </div>
            </div>
        </div>
    );
}

export default FooterTop;
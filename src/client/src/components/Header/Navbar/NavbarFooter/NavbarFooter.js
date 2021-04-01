import { Link } from 'react-router-dom';

import './NavbarFooter.css';

const NavbarFooter = () => {
    return(
        <ul className="nav header-navbar-rht">
            <li className="nav-item contact-item">
                <div className="header-contact-img">
                    <i className="far fa-hospital"></i>
                </div>
                <div className="header-contact-detail">
                    <p className="contact-header">Contact</p>
                    <p className="contact-info-header"> +1 315 369 5943</p>
                </div>
            </li>
            <li className="nav-item">
                <Link className="nav-link header-login" to="/login">login / Signup </Link>
            </li>
        </ul>
    );
}

export default NavbarFooter;
import { Link } from 'react-router-dom';

import authService from '../../../../services/authService';

import './NavbarFooter.css';

const NavbarFooter = () => {
    const user = authService.getCurrentUser();

    function onLogoutClickHandler() {
        authService.logout();
    }

    const link = user?.token 
        ? <Link className="nav-link header-login" onClick={ onLogoutClickHandler }>logout</Link> 
        : <Link className="nav-link header-login" to="/login">login / Signup </Link>;

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
                { link }
            </li>
        </ul>
    );
}

export default NavbarFooter;
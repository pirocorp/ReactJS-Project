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
                <a className="nav-link header-login" href="login.html">login / Signup </a>
            </li>
        </ul>
    );
}

export default NavbarFooter;
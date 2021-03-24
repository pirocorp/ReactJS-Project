import './NavbarHeader.css';

import { Link } from 'react-router-dom';

const NavbarHeader = () => {
    return(
        <div className="navbar-header">
            <div id="mobile_btn">
                <span className="bar-icon">
                    <span></span>
                    <span></span>
                    <span></span>
                </span>
            </div>
            <Link to="/" className="navbar-brand logo">
                <img src="/assets/img/logo.png" className="img-fluid" alt="Logo" />
            </Link>
        </div>
    );
}

export default NavbarHeader;
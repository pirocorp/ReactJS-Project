import './NavbarHeader.css';

import { Link } from 'react-router-dom';

const NavbarHeader = ({
    setOpenMenu
}) => {

    function onMobileMenuClickHandler() {
        setOpenMenu(true);
    }

    return(
        <div className="navbar-header">
            <div id="mobile_btn">
                <span className="bar-icon" onClick={onMobileMenuClickHandler}>
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
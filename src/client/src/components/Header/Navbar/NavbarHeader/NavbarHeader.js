import { useContext } from 'react';
import { Link } from 'react-router-dom';

import MobileMenuContext from '../../../../contexts/MobileMenuContext';

import './NavbarHeader.css';

const NavbarHeader = () => {

    const { setOpenMenu } = useContext(MobileMenuContext);

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
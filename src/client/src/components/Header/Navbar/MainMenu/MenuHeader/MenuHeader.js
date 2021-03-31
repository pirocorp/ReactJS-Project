import { Link } from 'react-router-dom';

import './MenuHeader.css';

const MenuHeader = ({
    setOpenMenu
}) => {
    function onMobileMenuCloseClickHandler() {
        setOpenMenu(false);
    }

    return(
        <div className="menu-header">
            <Link to="/" className="menu-logo">
                <img src="assets/img/logo.png" className="img-fluid" alt="Logo" />
            </Link>
            <span id="menu_close" className="menu-close" onClick={onMobileMenuCloseClickHandler}>
                <i className="fas fa-times"></i>
            </span>
        </div>
    );
}

export default MenuHeader;
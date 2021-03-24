import { Link } from 'react-router-dom';

import './MenuHeader.css';

const MenuHeader = () => {
    return(
        <div className="menu-header">
            <Link to="/" className="menu-logo">
                <img src="assets/img/logo.png" className="img-fluid" alt="Logo" />
            </Link>
            <Link id="menu_close" className="menu-close" to="/">
                <i className="fas fa-times"></i>
            </Link>
        </div>
    );
}

export default MenuHeader;
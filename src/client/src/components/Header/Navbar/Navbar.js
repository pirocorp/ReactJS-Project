import MainMenu from './MainMenu';
import NavbarHeader from './NavbarHeader';
import NavbarFooter from './NavbarFooter';

import './Navbar.css';


const Navbar = (props) => {
    return(
        <nav className="navbar navbar-expand-lg header-nav">
            <NavbarHeader {...props} />

            <MainMenu {...props} />

            <NavbarFooter {...props} />
        </nav>
    );
}

export default Navbar;
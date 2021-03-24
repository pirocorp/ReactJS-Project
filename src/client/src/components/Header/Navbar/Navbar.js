import MainMenu from './MainMenu';
import NavbarHeader from './NavbarHeader';
import NavbarFooter from './NavbarFooter';

import './Navbar.css';


const Navbar = () => {
    return(
        <nav className="navbar navbar-expand-lg header-nav">
            <NavbarHeader />

            <MainMenu />

            <NavbarFooter />
        </nav>
    );
}

export default Navbar;
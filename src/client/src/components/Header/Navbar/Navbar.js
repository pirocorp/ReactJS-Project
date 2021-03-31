import MainMenu from './MainMenu';
import NavbarHeader from './NavbarHeader';
import NavbarFooter from './NavbarFooter';

import './Navbar.css';


const Navbar = ({
    setOpenMenu
}) => {
    return(
        <nav className="navbar navbar-expand-lg header-nav">
            <NavbarHeader setOpenMenu={ setOpenMenu } />

            <MainMenu setOpenMenu={ setOpenMenu } />

            <NavbarFooter />
        </nav>
    );
}

export default Navbar;
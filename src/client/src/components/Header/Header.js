import './Header.css';

import Navbar from './Navbar'

const Header = ({
    setOpenMenu
}) => {
    return(
        <header className="header">
            <Navbar setOpenMenu={ setOpenMenu } />
        </header>
    );
}

export default Header;
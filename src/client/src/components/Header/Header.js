import { withRouter } from 'react-router-dom';

import Navbar from './Navbar'

import './Header.css';

const Header = ({
    setOpenMenu
}) => {
    return(
        <header className="header">
            <Navbar setOpenMenu={ setOpenMenu } />
        </header>
    );
}

export default withRouter(Header);
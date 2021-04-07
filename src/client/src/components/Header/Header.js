import { withRouter } from 'react-router-dom';

import Navbar from './Navbar'

import './Header.css';

const Header = () => {
    return(
        <header className="header">
            <Navbar />
        </header>
    );
}

export default withRouter(Header);
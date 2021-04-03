import { withRouter } from 'react-router-dom';

import Navbar from './Navbar'

import './Header.css';

const Header = (props) => {
    return(
        <header className="header">
            <Navbar { ...props } />
        </header>
    );
}

export default withRouter(Header);
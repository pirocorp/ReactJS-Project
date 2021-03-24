import { Link } from 'react-router-dom';

import './CopyrightMenu.css';

const CopyrightMenu = () => {
    return(
        <div className="copyright-menu">
            <ul className="policy-menu">
                <li><Link to="/term-condition">Terms and Conditions</Link></li>
                <li><Link to="/privacy-policy">Policy</Link></li>
            </ul>
        </div>
    );
}

export default CopyrightMenu;
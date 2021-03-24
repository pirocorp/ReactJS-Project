import { Link } from 'react-router-dom';

import './FooterMenu.css';

const FooterMenu = (props) => {
    return(
        <div className="footer-widget footer-menu">
            <h2 className="footer-title">{props.title}</h2>
            <ul>
                {props.links.map(x => <li key={x.path}><Link to={x.path}><i className="fas fa-angle-double-right"></i> {x.title}</Link></li>)}

            </ul>
        </div>
    );
}

export default FooterMenu;
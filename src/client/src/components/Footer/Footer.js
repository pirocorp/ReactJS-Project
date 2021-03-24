import FooterBottom from './FooterBottom';
import FooterTop from './FooterTop';

import './Footer.css';

const Footer = () => {
    return(
        <footer className="footer">
            <FooterTop />
            <FooterBottom />
        </footer>
    );
}

export default Footer;
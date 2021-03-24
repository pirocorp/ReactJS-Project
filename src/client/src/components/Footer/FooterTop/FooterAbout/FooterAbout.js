import { Link } from 'react-router-dom';

import './FooterAbout.css';

const FooterAbout = () => {
    return (
        <div className="footer-widget footer-about">
            <div className="footer-logo">
                <img src="/assets/img/footer-logo.png" alt="logo" />
            </div>
            <div className="footer-about-content">
                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. </p>
                <div className="social-icon">
                    <ul>
                        <li>
                            <Link to="#" target="_blank"><i className="fab fa-facebook-f"></i> </Link>
                        </li>
                        <li>
                            <Link to="#" target="_blank"><i className="fab fa-twitter"></i> </Link>
                        </li>
                        <li>
                            <Link to="#" target="_blank"><i className="fab fa-linkedin-in"></i></Link>
                        </li>
                        <li>
                            <Link to="#" target="_blank"><i className="fab fa-instagram"></i></Link>
                        </li>
                        <li>
                            <Link to="#" target="_blank"><i className="fab fa-dribbble"></i> </Link>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    );
}

export default FooterAbout;
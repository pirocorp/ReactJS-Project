import './FooterContact.css';

const FooterContact = () => {
    return (
        <div className="footer-widget footer-contact">
            <h2 className="footer-title">Contact Us</h2>
            <div className="footer-contact-info">
                <div className="footer-address">
                    <span><i className="fas fa-map-marker-alt"></i></span>
                    <p> 3556  Beech Street, San Francisco,<br /> California, CA 94108 </p>
                </div>
                <p>
                    <i className="fas fa-phone-alt"></i>
                    +1 315 369 5943
                </p>
                <p className="mb-0">
                    <i className="fas fa-envelope"></i>
                    doccure@example.com
                </p>
            </div>
        </div>
    );
}

export default FooterContact;
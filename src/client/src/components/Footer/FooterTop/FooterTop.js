import FooterWidget from './FooterWidget';
import FooterAbout from './FooterAbout';
import FooterContact from './FooterContact';
import FooterMenu from './FooterMenu';

import {routes} from '../../../common/applicationRoutes';

import './FooterTop.css';

const FooterTop = () => {
    return (
        <div className="footer-top">
            <div className="container-fluid">
                <div className="row">
                    <FooterWidget>
                        <FooterAbout />
                    </FooterWidget>
                    <FooterWidget>
                        <FooterMenu title="For Patients" links={routes.patients} />
                    </FooterWidget>
                    <FooterWidget>
                        <FooterMenu title="For Doctors" links={routes.doctors} />
                    </FooterWidget>
                    <FooterWidget>
                        <FooterContact />
                    </FooterWidget>
                </div>
            </div>
        </div>
    );
}

export default FooterTop;
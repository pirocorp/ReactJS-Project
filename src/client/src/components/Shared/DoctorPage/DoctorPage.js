import Breadcrumb from '../Breadcrumb';
import DoctorMenu from '../DoctorMenu';

import './DoctorPage.css';

function DoctorPage({
    children,
    doctorProfile
}) {
    return (
        <>
            <Breadcrumb active="Dashboard" title="Dashboard" />
            <div className="content">
                <div className="container-fluid">

                    <div className="row">
                        <div className="col-md-5 col-lg-4 col-xl-3 theiaStickySidebar">
                            <DoctorMenu doctorProfile={ doctorProfile } />
                        </div>

                        { children }
                    </div>
                </div>
            </div>
        </>
    );
}

export default DoctorPage;
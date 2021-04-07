import Breadcrumb from '../Breadcrumb';
import DoctorMenu from '../DoctorMenu';

import './DoctorPage.css';

function DoctorPage({
    children,
    doctorProfile,
    title
}) {
    return (
        <>
            <Breadcrumb homeName="Doctor" homeLink="/doctors/dashboard" active={title} title={title} />

            <div className="content">
                <div className="container-fluid">

                    <div className="row">
                        <div className="col-md-5 col-lg-4 col-xl-3 theiaStickySidebar">
                            <DoctorMenu doctorProfile={ doctorProfile } />
                        </div>   

                        <div className="col-md-7 col-lg-8 col-xl-9">
                            { children }    
                        </div>             
                    </div>
                    
                </div>
            </div>
        </>
    );
}

export default DoctorPage;
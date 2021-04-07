import Breadcrumb from '../Breadcrumb';

import PatientMenu from '../PatientMenu';

import './PatientPage.css';

function PatientPage({
    title,
    children,
    patientProfile
}) {

    return (
        <>
            <Breadcrumb homeLink="/patients/dashboard" homeName="Patient" active={title} title={title} />

            <div className="content">
                <div className="container-fluid">
                    <div className="row">
                        <PatientMenu patientProfile={patientProfile} />

                        <div className="col-md-7 col-lg-8 col-xl-9">
                            <div className="card">
                                <div className="card-body">

                                { children }
                                
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>           
        </>
    );
}

export default PatientPage;
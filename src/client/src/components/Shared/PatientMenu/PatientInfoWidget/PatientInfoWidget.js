import { useContext } from 'react';

import PatientContext from '../../../../contexts/PatientContext';

function PatientInfoWidget() {

    const patientProfile = useContext(PatientContext);

    if(!patientProfile?.id) {
        return <div className="profile-det-info"><h3>No Patient Profile Yet</h3></div>;
    }

    const fullName = `${patientProfile.firstName} ${patientProfile.lastName}`;
    const fullAddress = `${patientProfile.address}, ${patientProfile.city}`;

    return (
        <div className="profile-info-widget">
            <span href="#" className="booking-doc-img">
                <img src={patientProfile.imageUrl} alt={ fullName } />
            </span>
            <div className="profile-det-info">
                <h3>{ fullName }</h3>
                <div className="patient-details">
                    <h5 className="mb-0"><i className="fas fa-map-marker-alt"></i> { fullAddress }</h5>
                </div>
            </div>
        </div>
    );
}

export default PatientInfoWidget;
import DoctorPage from '../Shared/DoctorPage';

import './DoctorDashboard.css';

function DoctorDashboard({
    doctorProfile
}) {

    return(
        <DoctorPage title="Dashboard" doctorProfile={ doctorProfile }>
            
        </DoctorPage>
    );
}

export default DoctorDashboard;
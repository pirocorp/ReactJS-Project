function PatientInfoWidget({
    patientProfile
}) {
    return (
        <div class="profile-info-widget">
            <a href="#" class="booking-doc-img">
                <img src="assets/img/patients/patient.jpg" alt="User Image" />
            </a>
            <div class="profile-det-info">
                <h3>Richard Wilson</h3>
                <div class="patient-details">
                    <h5><i class="fas fa-birthday-cake"></i> 24 Jul 1983, 38 years</h5>
                    <h5 class="mb-0"><i class="fas fa-map-marker-alt"></i> Newyork, USA</h5>
                </div>
            </div>
        </div>
    );
}

export default PatientInfoWidget;
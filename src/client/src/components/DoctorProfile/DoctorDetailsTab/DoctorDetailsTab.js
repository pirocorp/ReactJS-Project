import BusinessHoursContent from './BusinessHoursContent';

import './DoctorDetailsTab.css';

function DoctorDetailsTab() {
    return (
        <div className="card">
            <div className="card-body pt-0">
                <div className="user-tabs mb-4">
                    <ul className="nav nav-tabs nav-tabs-bottom nav-justified">
                        <li className="nav-item">
                            <a className="nav-link active">Business Hours</a>
                        </li>
                    </ul>

                    <BusinessHoursContent />
                </div>
            </div>
        </div>
    );
}

export default DoctorDetailsTab;
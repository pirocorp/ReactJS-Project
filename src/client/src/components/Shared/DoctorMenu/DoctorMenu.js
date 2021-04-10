import { useState } from 'react'
import { Link, useHistory } from 'react-router-dom';

import './DoctorMenu.css';

function DoctorMenu({
    doctorProfile
}) {
    
    const [path, setPath] = useState('');

    const history = useHistory()

    if(path != history.location.pathname) {
        setPath(history.location.pathname);
    }

    const isActive = (e) => path.includes(e) ? 'active'  : '';

    return (
        <div className="profile-sidebar">
            <div className="widget-profile pro-widget-content">
                <div className="profile-info-widget">
                    <span className="booking-doc-img">
                        <img src={doctorProfile?.imageUrl ?? ''} alt={`Doctor ${doctorProfile?.firstName ?? ''} ${doctorProfile?.lastName ?? ''}`} />
                    </span>
                    <div className="profile-det-info">
                        <h3>Dr. { `${doctorProfile?.firstName ?? ''} ${doctorProfile?.lastName ?? ''}` }</h3>

                        <div className="patient-details">
                            <h5 className="mb-0">{ doctorProfile?.education }</h5>
                        </div>
                    </div>
                </div>
            </div>
            <div className="dashboard-widget">
                <nav className="dashboard-menu">
                    <ul>
                        <li className={ isActive('appointments') }>
                            <Link to="/doctors/appointments">
                                <i className="fas fa-calendar-check"></i>
                                <span>Appointments</span>
                            </Link>
                        </li>
                        {/* <li className={ isActive('my-patients') }>
                            <Link to="/doctors/my-patients">
                                <i className="fas fa-user-injured"></i>
                                <span>My Patients</span>
                            </Link>
                        </li> */}
                        <li className={ isActive('shifts') }>
                            <Link to="/doctors/shifts">
                                <i className="fas fa-hourglass-start"></i>
                                <span>Schedule Shifts</span>
                            </Link>
                        </li>
                        {/* <li className={ isActive('profile') }>
                            <Link to="/doctors/profile">
                                <i className="fas fa-user-cog"></i>
                                <span>Profile</span>
                            </Link>
                        </li> */}
                    </ul>
                </nav>
            </div>
        </div>
    );
}

export default DoctorMenu;
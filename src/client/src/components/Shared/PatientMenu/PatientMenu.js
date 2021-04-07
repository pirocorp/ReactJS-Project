import { useState } from 'react'
import { Link, useHistory } from 'react-router-dom';

import PatientInfoWidget from './PatientInfoWidget';

import './PatientMenu.css';

function PatientMenu({
    patientProfile
}) {
    const [path, setPath] = useState('');

    const history = useHistory()

    if(path !== history.location.pathname) {
        setPath(history.location.pathname);
    }

    const isActive = (e) => path.includes(e) ? 'active'  : '';

    const patientInfoElement = patientProfile 
        ? <PatientInfoWidget patientProfile={patientProfile} />
        : <div className="profile-det-info"><h3>No Patient Profile Yet</h3></div>;

    return (
        <div className="col-md-5 col-lg-4 col-xl-3 theiaStickySidebar">
            <div className="profile-sidebar">
                <div className="widget-profile pro-widget-content">

                    { patientInfoElement }

                </div>
                <div className="dashboard-widget">
                    <nav className="dashboard-menu">
                        <ul>
                            <li className={ isActive('dashboard') }>
                                <Link to="/patients/dashboard">
                                    <i className="fas fa-columns"></i>
                                    <span>Dashboard</span>
                                </Link>
                            </li>
                            <li className={ isActive('profile') }>
                                <Link to="/patients/profile">
                                    <i className="fas fa-user-cog"></i>
                                    <span>Profile Settings</span>
                                </Link>
                            </li>
                        </ul>
                    </nav>
                </div>

            </div>
        </div>
    );
}

export default PatientMenu;
import { useEffect, useState, useContext } from 'react';
import { Link } from 'react-router-dom';

import patientsService from '../../services/patientService';

import PatientContext from '../../contexts/PatientContext';

import PatientPage from '../Shared/PatientPage';
import PatientAppointment from './PatientAppointment';

import './PatientDashboard.css';

function PatientDashboard() {
    const patient = useContext(PatientContext);

    const [appointments, setAppointments] = useState([]);

    useEffect(() => {
        updateAppointments();
    }, [patient]);

    const updateAppointments = () => {
        patientsService.getPatientAppointments(patient.id)
            .then(res => { 
                setAppointments(res);
                
                console.log(res);
            });
    };

    return (
        <PatientPage title="Dashboard">
        <nav className="user-tabs mb-4">
            <ul className="nav nav-tabs nav-tabs-bottom nav-justified">
                <li className="nav-item">
                    <Link className="nav-link active" to="#pat_appointments" data-toggle="tab">Appointments</Link>
                </li>
            </ul>
        </nav>

        <div className="tab-content pt-0">
            <div id="pat_appointments" className="tab-pane fade show active">
                <div className="card card-table mb-0">
                    <div className="card-body">
                        <div className="table-responsive">
                            <table className="table table-hover table-center mb-0">
                                <thead>
                                    <tr>
                                        <th>Doctor</th>
                                        <th>Specializations</th>
                                        <th>Appt Date</th>
                                        <th>Booking Date</th>
                                        <th>Status</th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    { appointments?.map(a => 
                                        <PatientAppointment 
                                            key={a.id} 
                                            updateAppointments={ updateAppointments } 
                                            appointment={a} 
                                            patientId={ patient.id }
                                        />) }
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </PatientPage>
    );
}

export default PatientDashboard;
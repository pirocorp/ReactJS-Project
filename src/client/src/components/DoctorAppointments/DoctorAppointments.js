import { useEffect, useState } from 'react';
import { useHistory } from 'react-router-dom';

import DoctorPage from '../Shared/DoctorPage';
import DoctorAppointment from './DoctorAppointment';
import DoctorAppointmentsNavigation from './DoctorAppointmentsNavigation';

import doctorsService from '../../services/doctorsService';

import './DoctorAppointments.css';

function DoctorAppointments({
    doctorProfile
}) {

    const [appointments, setAppointments] = useState([]);
    const [type, setType] = useState('today');

    let history = useHistory();

    useEffect(() => {        
        const hash = history.location.hash;

        if(hash) {
            setType(hash.slice(1))
        }
    }, [])

    useEffect(() => {     
        doctorsService.getAppointments(doctorProfile.id, type)
            .then(res => setAppointments(res ?? []))
    }, [doctorProfile, type])    

    return (
        <DoctorPage title="Dashboard" doctorProfile={doctorProfile}>
            <div className="col-md-7 col-lg-8 col-xl-9">
                <div className="row">
                    <div className="col-md-12">                       

                        <div className="appointment-tab">

                            <DoctorAppointmentsNavigation type={ type } setType={setType} />

                            <div className="tab-content">

                                <div className="tab-pane show active" id="upcoming-appointments">
                                    <div className="card card-table mb-0">
                                        <div className="card-body">
                                            <div className="table-responsive">
                                                <table className="table table-hover table-center mb-0">
                                                    <thead>
                                                        <tr>
                                                            <th>Patient Name</th>
                                                            <th>Appt Date</th>
                                                            <th className="text-center">Status</th>
                                                            <th></th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        { appointments.map(a => <DoctorAppointment key={a.id} appointment={ a } />) }
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>                       
                            
                        </div>
                    </div>
                </div>
            </div>
        </DoctorPage>
    );
}

export default DoctorAppointments;
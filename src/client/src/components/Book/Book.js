import { useState, useEffect, useContext } from 'react';

import authService from '../../services/authService';
import doctorService from '../../services/doctorsService';
import patientsService from '../../services/patientService';
import usersService from '../../services/usersService';

import UserContext from '../../contexts/UserContext';

import BreadCrumbs from '../Shared/Breadcrumb';
import DoctorBookCard from './DoctorBookCard';
import DoctorBookSchedule from './DoctorBookSchedule';

import './Book.css';

function Book({
    match,
    history
}) {
    const doctorId = match.params.doctorId;

    const { user } = useContext(UserContext);
    const [ doctor, setDoctor ] = useState({});
    const [ patientId, setPatientId ] = useState(''); 

    const [ payload, setPayload ] = useState({});

    useEffect(() => {
        doctorService
            .get(doctorId)
            .then(doctor => setDoctor(doctor));

        const userId = authService.getUserId(user?.token);

        usersService
            .getProfileId(userId)
            .then(res => setPatientId(res.profileId));

    }, [doctorId]);

    

    const createAppointment = () => {
        patientsService.createAppointment(patientId, payload)
            .then(res => history.push(`/booking-success/${res.appointmentId}`))
            .catch(res => console.log(res));
    }

    return (
        <>
            <BreadCrumbs homeLink="/patients/search" homeName="Search" active="Book Doctor" title="Book Doctor" />

            <div className="content">
                <div className="container">

                    <div className="row">
                        <div className="col-12">
                            <DoctorBookCard { ... doctor }/>

                            <DoctorBookSchedule doctorId={ doctorId } payload={ payload } setPayload={ setPayload }/>

                            <div class="submit-section proceed-btn text-right">
								<button onClick={ createAppointment } class="btn btn-primary submit-btn">Make Appointment</button>
							</div>
                        </div>
                    </div>
                </div>                

            </div>
        </>
    );
}

export default Book;
import { useEffect, useState, useContext } from 'react';

import UserContext from '../../../../contexts/UserContext';

import slotsService from '../../../../services/slotsService';
import authService from '../../../../services/authService';
import usersService from '../../../../services/usersService';

import './TimeSlots.css';
import patientsService from '../../../../services/patientService';

function TimeSlots({
    dates,
    doctorId
}) {

    const { user } = useContext(UserContext);
    const [ slots, setSlots ] = useState([]);
    const [ appointments, setAppointments ] = useState([]);
    const [ patientId, setPatientId ] = useState('');

    useEffect(() => {
        slotsService
            .getAll()
            .then(res => setSlots(res ?? []));

        const userId = authService.getUserId(user?.token);

        usersService
            .getProfileId(userId)
            .then(res => {
                setPatientId(res.profileId);

                return patientsService.getPatientAppointments(res.profileId);
            })
            .then(res => setAppointments(res.filter(a => a.status.name !== 'Canceled')));        
    }, []);

    const mapSlots = (date) => {
        
        const onlyDate = date?.toISOString().split('T')[0];
        const sameDateAppointments = appointments.filter(a => a.date.split('T')[0] === onlyDate);

        return slots
            .map(s => (
                <span 
                    key={ s.id } 
                    id={ s.id } 
                    className={sameDateAppointments.some(a => a.slot === s.name)? 'timing taken' : 'timing'} 
                    onClick={ (e) => onTimeSlotClickHandler(e, date) }
                >
                    <span>{ s.name }</span>
                </span>
            ));
    }

    const onTimeSlotClickHandler = (e, date) => {
        const slotId = e.currentTarget.id;

        const datePayload = new Date(Date.UTC(date.getFullYear(), date.getMonth(), date.getDate())).toJSON();
        const payload = {
            doctorId,
            slotId,
            date: datePayload
        };

        // TODO: Set Another state for selected slot and when button is clicked appointment is made
        // Clicking one slot deselect another clicked
        // Update appointments after new appointment is send to backend
        
        patientsService.createAppointment(patientId, payload)
            .then(res => console.log(res))
            .catch(res => console.log(res));
    };

    return (
        <div className="schedule-cont">
            <div className="row">
                <div className="col-md-12">

                    <div className="time-slot">
                        <ul className="clearfix">
                            <li>
                                { mapSlots(dates[0]) }
                            </li>
                            <li>
                                { mapSlots(dates[1]) }
                            </li>
                            <li>
                                { mapSlots(dates[2]) }  
                            </li>
                            <li>
                                { mapSlots(dates[3]) }
                            </li>
                            <li>
                                { mapSlots(dates[4]) }
                            </li>
                            <li>
                                { mapSlots(dates[5]) }
                            </li>
                            <li>
                                { mapSlots(dates[6]) }
                            </li>
                        </ul>
                    </div>

                </div>
            </div>
        </div>

    );
}

export default TimeSlots;
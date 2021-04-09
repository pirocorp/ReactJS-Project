import { useEffect, useState } from 'react';

import doctorsService from '../../../../services/doctorsService';
import slotsService from '../../../../services/slotsService';

import './TimeSlots.css';

function TimeSlots({
    dates,
    doctorId,
    payload,
    setPayload,
}) {

    const [ slots, setSlots ] = useState([]);
    const [ appointments, setAppointments ] = useState([]);       

    useEffect(() => {
        slotsService
            .getAll()
            .then(res => setSlots(res ?? []));

        doctorsService
            .getAppointments(doctorId)
            .then(res => setAppointments(res.filter(a => a.status !== 'Canceled')));        
    }, []);

    const mapSlots = (date) => {
        
        const onlyDate = date?.toISOString().split('T')[0];
        const sameDateAppointments = appointments.filter(a => a.shift.date.split('T')[0] === onlyDate);

        return slots
            .map(s => (
                <span 
                    key={ s.id } 
                    id={ s.id } 
                    className={
                        sameDateAppointments.some(a => a.slot.name === s.name)
                            ? 'timing taken' 
                            : s.id === payload?.slotId && payload.date.split('T')[0] === onlyDate
                                ? 'timing selected' 
                                : 'timing'
                    } 
                    onClick={ (e) => onTimeSlotClickHandler(e, date) }
                >
                    <span>{ s.name }</span>
                </span>
            ));
    }

    const onTimeSlotClickHandler = (e, date) => {
        if(e.currentTarget.className.includes('taken')) {                        
            return;
        }

        const slotId = e.currentTarget.id;

        const datePayload = new Date(Date.UTC(date.getFullYear(), date.getMonth(), date.getDate())).toJSON();

        const payload = {
            doctorId,
            slotId,
            date: datePayload
        };

        setPayload(payload);   
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
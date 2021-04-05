import { useEffect, useState } from 'react';

import FullCalendar from '@fullcalendar/react';
import dayGridPlugin from '@fullcalendar/daygrid';
import interactionPlugin from "@fullcalendar/interaction";

import doctorsService from '../../services/doctorsService';

import DoctorPage from '../Shared/DoctorPage';

import './DoctorSchedule.css';

function DoctorSchedule({
    doctorProfile
}) {

    const [events, setEvents] = useState([]);

    useEffect(() => {
        if(!doctorProfile?.id) {
            return;
        }

        doctorsService
            .getShifts(doctorProfile.id)
            .then(res => {
                setEvents(res);
                console.log(events);

                //res must be converted to events and added to state;
            });

    }, [doctorProfile]);

    function onDateClickHandler(args) {
        // on date click this function will be called
        // this function must do post to backend with new shift
        // and in case of success change state of the component
        console.log("Yaaa");
        console.log(args);
    }

    let calendar =  
        <FullCalendar 
            plugins = {[ dayGridPlugin, interactionPlugin ]}
            initialView = "dayGridMonth"
            events={[
                { title: 'event 1', date: '2021-04-01' },
                { title: 'event 2', date: '2021-04-02' }
            ]}
            dateClick={ onDateClickHandler }
        />;

    return (
        <DoctorPage doctorProfile={doctorProfile}>
            { calendar }
        </DoctorPage>
    );   
}

export default DoctorSchedule;
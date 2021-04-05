import React from 'react';

import FullCalendar from '@fullcalendar/react';
import dayGridPlugin from '@fullcalendar/daygrid';
import interactionPlugin from "@fullcalendar/interaction";

import DoctorPage from '../Shared/DoctorPage';

import './DoctorSchedule.css';

class DoctorSchedule extends React.Component {
    constructor(props) {
        super(props);

        this.doctorProfile = props.doctorProfile;
        this.onDateClickHandler.bind(this);
    };

    // events are doctor shifts

    onDateClickHandler(args) {
        console.log("Yaaa");
        console.log(args);
    }

    render() {

        let calendar =  
            <FullCalendar 
                plugins = {[ dayGridPlugin, interactionPlugin ]}
                initialView = "dayGridMonth"
                events={[
                    { title: 'event 1', date: '2021-04-01' },
                    { title: 'event 2', date: '2021-04-02' }
                ]}
                dateClick={ this.onDateClickHandler }
            />;

        return (
            <DoctorPage doctorProfile={this.doctorProfile}>
                { calendar }
            </DoctorPage>
        );
    }    
}

export default DoctorSchedule;
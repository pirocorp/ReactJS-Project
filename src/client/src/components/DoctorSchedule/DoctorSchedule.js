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
        if (!doctorProfile?.id) {
            return;
        }

        let view = calendar.view;

        console.log(view);

        updateShifts();

    }, [doctorProfile]);

    const updateShifts = () => doctorsService
        .getShifts(doctorProfile.id)
        .then(res => setEvents(res.map(r => ({ date: r.date.split('T')[0], title: 'On Duty', id: r.id }))));


    function onDateClickHandler(args) {
        const date = new Date(Date.UTC(args.date.getFullYear(), args.date.getMonth(), args.date.getDate())).toJSON();

        if (args.dayEl.innerText.includes('On Duty')) {
            return;
        }

        const payload = {
            date: date,
        };

        doctorsService.postShift(doctorProfile.id, payload)
            .then(res => updateShifts());
    };

    function onEventClickHandler(info) {
        let shiftId = info.event.id;

        doctorsService.deleteShift(doctorProfile.id, shiftId)
            .then(res => updateShifts());
    };

    let calendar =
        <FullCalendar
            plugins={[dayGridPlugin, interactionPlugin]}
            initialView="dayGridMonth"
            events={events}
            dateClick={onDateClickHandler}
            eventClick={onEventClickHandler}
            fixedWeekCount={false}
        />;

    return (
        <DoctorPage doctorProfile={doctorProfile}>
            <div class="col-md-7 col-lg-8 col-xl-9">
                <div class="card">
                    <div class="card-body">
                        {calendar}
                    </div>
                </div>
            </div>

        </DoctorPage>
    );
}

export default DoctorSchedule;
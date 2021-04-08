import { useState, useEffect} from 'react';

import DaySlots from './DaySlots';
import TimeSlots from './TimeSlots';

import './DoctorBookSchedule.css';

function DoctorBookSchedule({
    doctorId
}) {
    const [startDate, setStartDate] = useState({ });
    const [dates, setDates] = useState([]);

    useEffect(() => {
        const startDate = new Date();
        startDate.setDate(startDate.getDate() + 1);

        setStartDate(startDate);
    }, [])

    return (
        <div className="card booking-schedule schedule-widget">

            <div className="schedule-header">
                <div className="row">
                    <div className="col-md-12">

                    <DaySlots 
                        startDate={ startDate } 
                        setStartDate={ setStartDate } 
                        dates={ dates }
                        setDates={ setDates }
                    />

                    </div>
                </div>
            </div>

            <TimeSlots dates={ dates } doctorId={ doctorId } />

        </div>

    );
}

export default DoctorBookSchedule;
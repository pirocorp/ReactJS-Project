import { useState, useEffect} from 'react';

import DaySlots from './DaySlots';

import './DoctorBookSchedule.css';

function DoctorBookSchedule() {

    const [startDate, setStartDate] = useState({ });

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
                    />

                    </div>
                </div>
            </div>



        </div>

    );
}

export default DoctorBookSchedule;
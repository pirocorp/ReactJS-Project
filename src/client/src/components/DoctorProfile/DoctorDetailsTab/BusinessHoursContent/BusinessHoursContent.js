import { useEffect, useState } from 'react';

import slotsService from '../../../../services/slotsService';

import BusinessHours from '../../../Shared/BusinessHours';

import './BusinessHoursContent.css';

function BusinessHoursContent() {

    const[time, setTime] = useState({
        openTime: '00:00',
        closeTime: '00:00',
        date: new Date()
    });

    useEffect(() => {
        slotsService.getAll()
            .then(res => { 
                
                if(!res){
                    return;
                }

                const firstSlot = res[0];
                const lastSlot = res[res.length - 1];

                setTime((state) => {
                    const openTime = `${firstSlot?.startHour.toString().padStart(2, "0")}:${firstSlot?.startMin.toString().padStart(2, "0")}`;
                    const closeTime = `${lastSlot?.endHour.toString().padStart(2, "0")}:${lastSlot?.endMin.toString().padStart(2, "0")}`;

                    const newState = {
                        openTime,
                        closeTime,
                        date: state.date
                    };

                    return newState;
                }); 
            });
    }, []);

    function isOpen() {

        return false;
    }

    return (
        <div className="tab-content pt-0 my-4">
            <div role="tabpanel" id="doc_business_hours" className="tab-pane fade active show">
                <div className="row">
                    <div className="col-md-6 offset-md-3">

                        <div className="widget business-widget">
                            <div className="widget-content">
                                <div className="listing-hours">
                                    
                                    <div className="listing-day current">
                                        <div className="day">Today <span>{time.date.getDate()} {time.date.toLocaleString('default', {month: 'long'})} {time.date.getFullYear()} ({time.date.toLocaleString('default', {weekday: 'long'})})</span></div>
                                        <div className="time-items">

                                            {isOpen() 
                                                ? <span className="open-status"><span className="badge bg-success-light">Open Now</span></span>
                                                : <span className="time"><span className="badge bg-danger-light">Closed</span></span>
                                            }
                                            
                                            <span className="time">{`${time.openTime} - ${time.closeTime}`}</span>
                                        </div>
                                    </div>
                                    
                                    <BusinessHours dayOfWeek="Monday" openTime={time.openTime} closeTime={time.closeTime} />
                                    <BusinessHours dayOfWeek="Tuesday" openTime={time.openTime} closeTime={time.closeTime} />
                                    <BusinessHours dayOfWeek="Wednesday" openTime={time.openTime} closeTime={time.closeTime} />
                                    <BusinessHours dayOfWeek="Thursday" openTime={time.openTime} closeTime={time.closeTime} />
                                    <BusinessHours dayOfWeek="Friday" openTime={time.openTime} closeTime={time.closeTime} />
                                    <BusinessHours dayOfWeek="Saturday" openTime={time.openTime} closeTime={time.closeTime} />
                                    <BusinessHours dayOfWeek="Sunday" isClosed />
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    );
}

export default BusinessHoursContent;
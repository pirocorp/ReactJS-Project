import { useEffect } from 'react';

import './DaySlots.css';

function Days({
    startDate,
    setStartDate,
    dates,
    setDates
}) {
    const minDate = new Date();
    minDate.setDate(minDate.getDate() + 1);

    const days = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];    

    useEffect(() => {

        let endDate = new Date(startDate);
        endDate.setDate(endDate.getDate() + 6);

        const dates = [];

        if(typeof startDate.getMonth !== 'function'){
            return;
        }

        for (let d = new Date(startDate); d <= endDate; d.setDate(d.getDate() + 1)) {
            dates.push(new Date(d));   
        }

        setDates(dates);
    }, [startDate]);

    const increaseDates = () => {
        setStartDate(state => {
            
            console.log(state);

            const newStartDate = new Date(state);
            newStartDate.setDate(newStartDate.getDate() + 1);

            return newStartDate;
        });
    };

    const decreaseDates = () => {        
        setStartDate(state => {

            if(state <= minDate){
                return state;
            }

            const newStartDate = new Date(state);
            newStartDate.setDate(newStartDate.getDate() - 1);           
            
            return newStartDate;
        });
    };

    return (
        <div className="day-slot">
            <ul>
                <li className="left-arrow" onClick={ decreaseDates }>
                    <span>
                        <i className="fa fa-chevron-left"></i>
                    </span>
                </li>
                {
                    dates.map(d => (
                        <li key={ d.getTime() }>
                            <span>{ days[d.getDay()].slice(0, 3) }</span>
                            <span className="slot-date">{ d.getDate() + ' ' + d.toLocaleString('default', { month: 'short' }) } 
                                <small className="slot-year"> { d.getFullYear() }</small>
                            </span>
                        </li>
                    ))
                }

                <li className="right-arrow" onClick={ increaseDates }>
                    <span>
                        <i className="fa fa-chevron-right"></i>
                    </span>
                </li>
            </ul>
        </div>
    );
}

export default Days;
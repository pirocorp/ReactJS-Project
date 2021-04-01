import './BusinessHours.css';

function BusinessHours({
    dayOfWeek,
    openTime,
    closeTime,
    isClosed
}) {
    return(
        <div className="listing-day">
            <div className="day">{dayOfWeek}</div>
            <div className="time-items">
                {isClosed ? <span className="time"><span className="badge bg-danger-light">Closed</span></span> : <span className="time">{openTime} - {closeTime}</span>}
            </div>
        </div>
    );
}

export default BusinessHours;
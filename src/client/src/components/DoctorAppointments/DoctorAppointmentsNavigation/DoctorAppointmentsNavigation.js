import './DoctorAppointmentsNavigation.css';

function DoctorAppointmentsNavigation({
    type,
    setType
}) {
    const setActive = (name) => type === name ? 'active' : '';

    return (
        <ul className="nav nav-tabs nav-tabs-solid nav-tabs-rounded">
            <li className="nav-item" onClick={() => setType('upcoming')}>
                <a className={`nav-link ${setActive('upcoming')}`} href="#upcoming" data-toggle="tab">Upcoming</a>
            </li>
            <li className="nav-item" onClick={() => setType('today')}>
                <a className={`nav-link ${setActive('today')}`} href="#today" data-toggle="tab">Today</a>
            </li>
            <li className="nav-item" onClick={() => setType('past')}>
                <a className={`nav-link ${setActive('past')}`} href="#past" data-toggle="tab">Past</a>
            </li>
        </ul>
    );
}

export default DoctorAppointmentsNavigation;
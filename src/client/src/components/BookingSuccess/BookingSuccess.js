import { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';

import appointmentsService from '../../services/appointmentsService';

import Breadcrumb from '../Shared/Breadcrumb';

import './BookingSuccess.css';

function BookingSuccess({
	match
}) {
	const appointmentId = match.params.appointmentId;
	const [ appointment, setAppointment ] = useState({});

	useEffect(() => {
		appointmentsService.get(appointmentId)
			.then(res => {setAppointment(res); console.log(res);});
	}, []);

	const fullName = `Dr. ${appointment?.firstName} ${appointment?.lastName}`;
	const date = appointment.date
		?.split('T')[0]
		.replaceAll('-', ' ');
	const time = appointment.slot
		?.replaceAll('-', ' to ')

    return(
        <>
            <Breadcrumb homeLink="/" homeName="Home" active="Booking" title="Booking" />

            <div className="content success-page-cont">
				<div className="container-fluid">
				
					<div className="row justify-content-center">
						<div className="col-lg-6">
						
							<div className="card success-card">
								<div className="card-body">
									<div className="success-cont">
										<i className="fas fa-check"></i>
										<h3>Appointment booked Successfully!</h3>
										<p>Appointment booked with <strong>{ fullName }</strong><br /> on <strong>{ date } from { time }</strong></p>
										<Link to="/" className="btn btn-primary view-inv-btn">OK</Link>
									</div>
								</div>
							</div>
							
						</div>
					</div>
					
				</div>
			</div>
        </>
    );
}

export default BookingSuccess;
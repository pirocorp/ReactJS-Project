import { Link } from 'react-router-dom';
import patientsService from '../../../services/patientService';

import patientService from '../../../services/patientService';

import SpecializationIcon from '../../Shared/DoctorCard/SpecializationIcon';

import './PatientAppointment.css';

function PatientAppointment({
    appointment,
    updateAppointments,
    patientId
}) {
    const doctorFullName = `Dr. ${appointment.doctor.firstName} ${appointment.doctor.lastName}`;
    const date = appointment.date.split('T')[0].replaceAll('-', ' ').split(' ').reverse().join(' / ');
    const bookDate = appointment.createdOn.split('T')[0].replaceAll('-', ' ').split(' ').reverse().join(' / ');
    
    const statusClass = (statusName) => {
        switch(statusName) {
            case "Confirmed":
                return 'bg-success-light';
            case "Canceled":
                return 'bg-danger-light';
            case "Pending":
                return 'bg-warning-light';
            case "Completed":
                return 'bg-primary-light';
        }
    };

    const onAppointmentCancelClickHandler = (appointmentId) => {
        patientsService
            .cancelAppointment(patientId, appointmentId)
            .then(res => updateAppointments());
    }

    const cancelElement = appointment.status.name === "Pending" || appointment.status.name === "Confirmed"
        ? (<button to="#" className="btn btn-sm bg-danger-light" onClick={ () => onAppointmentCancelClickHandler(appointment.id) }>
                <i className="far fa-eye"></i> Cancel
            </button>)
        : '';

    return (
        <tr>
            <td>
                <h2 className="table-avatar">
                    <Link to="#" className="avatar avatar-sm mr-2">
                        <img className="avatar-img rounded-circle" src={appointment.doctor.imageUrl} alt="User Image" />
                    </Link>
                    <Link to="#">
                        { doctorFullName }
                    </Link>
                </h2>
            </td>
            <td>
                <span>{appointment.doctor.specializations.map(s => <SpecializationIcon style={{maxWidth: '30px', marginRight: '5px'}} key={ s.id } {...s}/>)}</span>
            </td>
            <td>{ date } <span className="d-block text-info">{ appointment.slot }</span></td>
            <td>{ bookDate }</td>            
            <td><span className={'badge badge-pill ' + statusClass(appointment.status.name)}>{ appointment.status.name }</span></td>
            <td className="text-right">
                <div className="table-action">
                    { cancelElement }
                </div>
            </td>
        </tr>
    );
}

export default PatientAppointment;
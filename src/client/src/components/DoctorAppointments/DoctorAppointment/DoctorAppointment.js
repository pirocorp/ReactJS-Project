import { convertDate, statusClass } from '../../../common/helpers';

import appointmentsService from '../../../services/appointmentsService';

import './DoctorAppointment.css';

function DoctorAppointment({
    appointment,
    updateAppointments
}) {
    const patientName = `${appointment.patient.firstName} ${appointment.patient.lastName}`;
    const appointmentDate = convertDate(appointment.shift.date);

    const onButtonClickHandler = (status) => {
        const appointmentId = appointment.id;

        appointmentsService
            .updateStatus(appointmentId, status)
            .then(res => updateAppointments())
            .catch(res => console.log(res));
    }

    const tableActionElement = (appointmentStatus) => {
        switch(appointmentStatus) {
            case 'Confirmed':
                return (
                    <div className="table-action" onClick={ () => onButtonClickHandler('Completed') }>
                        <button className="btn btn-sm bg-info-light mr-1">
                            <i class="fas fa-archive"></i> Complete
                        </button>
                    </div>
                );
            case 'Pending':
                return (
                    <div className="table-action">
                        <button className="btn btn-sm bg-info-light mr-1" onClick={ () => onButtonClickHandler('Completed') }>
                            <i class="fas fa-archive"></i> Complete
                        </button>
                        <button href="#" className="btn btn-sm bg-success-light mr-1" onClick={ () => onButtonClickHandler('Confirmed') }>
                            <i className="fas fa-check"></i> Accept
                        </button>
                        <button href="#" className="btn btn-sm bg-danger-light mr-1" onClick={ () => onButtonClickHandler('Canceled') }>
                            <i className="fas fa-times"></i> Cancel
                        </button>
                    </div>
                );
        }
    };

    return (
        <tr>
            <td>
                <h2 className="table-avatar">
                    <div>
                        <img 
                            className="avatar-img rounded-circle appointment-patient-image" 
                            src={appointment.patient.imageUrl} 
                            alt="User Image" 
                        />
                    </div>
                    <span >{ patientName }</span>
                </h2>
            </td>
            <td>{ appointmentDate } <span className="d-block text-info">{ appointment.slot.name }</span></td>
            <td className="text-center">
                <span className={`badge badge-pill ${statusClass(appointment.status)}`}>{ appointment.status }</span>
            </td>
            <td className="text-right">
                { tableActionElement(appointment.status) }
            </td>
        </tr>
    );
}

export default DoctorAppointment;
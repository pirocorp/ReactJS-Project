import requesterService from './requesterService';

const endpoint = '/patients';
const cancel = '/cancel'

const createPatientProfile = (data) => requesterService.sendData(endpoint, 'POST', data);
const updatePatientProfile = (data, id) => requesterService.sendData(`${endpoint}/${id}`, 'PUT', data);
const getProfile = (id) => requesterService.get(`${endpoint}/${id}`);
const createAppointment = (patientId, data) => requesterService.post(`${endpoint}/${patientId}/appointments`, data);
const getPatientAppointments = (patientId) => requesterService.get(`${endpoint}/${patientId}/appointments`);
const cancelAppointment = (patientId, appointmentId) => requesterService.patch(`${endpoint}/${patientId}/appointments/${appointmentId}${cancel}`);

const patientsService = {
    createPatientProfile,
    updatePatientProfile,
    getProfile,
    createAppointment,
    getPatientAppointments,
    cancelAppointment
};

export default patientsService;
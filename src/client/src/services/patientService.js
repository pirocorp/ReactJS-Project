import requesterService from './requesterService';

const endpoint = '/patients';

const createPatientProfile = (data) => requesterService.sendData(endpoint, 'POST', data);
const updatePatientProfile = (data, id) => requesterService.sendData(`${endpoint}/${id}`, 'PUT', data);
const getProfile = (id) => requesterService.get(`${endpoint}/${id}`);

const patientsService = {
    createPatientProfile,
    updatePatientProfile,
    getProfile
};

export default patientsService;
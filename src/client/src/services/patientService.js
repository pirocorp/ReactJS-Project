import requesterService from './requesterService';

const endpoint = '/patients';

const createPatientProfile = (data) => requesterService.sendData(endpoint, data);
const getProfile = (id) => requesterService.get(`${endpoint}/${id}`);

const patientsService = {
    createPatientProfile,
    getProfile
};

export default patientsService;
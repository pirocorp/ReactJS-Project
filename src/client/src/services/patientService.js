import requesterService from './requesterService';

const endpoint = '/patients';

const createPatientProfile = (data) => requesterService.sendData(endpoint, data);

const patientsService = {
    createPatientProfile,
};

export default patientsService;
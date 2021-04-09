import requesterService from './requesterService';

const endpoint = '/doctors';
const shifts = '/shifts';
const appointments = '/appointments';

function getAll (queryString) {
    let uri = endpoint;

    if(queryString){
        uri += queryString;
    }

    return requesterService.get(uri);
}

const get = (id) => requesterService.get(`${endpoint}/${id}`);

const getShifts = (id) => requesterService.get(`${endpoint}/${id}${shifts}`);

const postShift = (id, data) => requesterService.post(`${endpoint}/${id}${shifts}`, data);

const deleteShift = (doctorId, shiftId) => requesterService.del(`${endpoint}/${doctorId}${shifts}/${shiftId}`);

const getAppointments = (doctorId) => requesterService.get(`${endpoint}/${doctorId}${appointments}`);

const doctorsService = {
    getAll,
    get,
    getShifts,
    postShift,
    deleteShift,
    getAppointments,
};

export default doctorsService;
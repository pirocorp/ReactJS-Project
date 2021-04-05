import requesterService from './requesterService';

const endpoint = '/doctors';
const shifts = '/shifts';

function getAll (queryString) {
    let uri = endpoint;

    if(queryString){
        uri += queryString;
    }

    return requesterService.get(uri);
}

const get = (id) => requesterService.get(`${endpoint}/${id}`);

const getShifts = (id) => requesterService.get(`${endpoint}/${id}${shifts}`);

const doctorsService = {
    getAll,
    get,
    getShifts
};

export default doctorsService;
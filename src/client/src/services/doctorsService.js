import requesterService from './requesterService';

const endpoint = '/doctors';

function getAll (queryString) {
    let uri = endpoint;

    if(queryString){
        uri += queryString;
    }

    return requesterService.get(uri);
}

const get = (id) => requesterService.get(`${endpoint}/${id}`);

const doctorsService = {
    getAll,
    get
};

export default doctorsService;
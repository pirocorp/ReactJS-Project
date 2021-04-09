import requesterService from './requesterService';

const endpoint = '/appointments';

const get = (id) => {
    const uri = endpoint + '/' + id;   

    return requesterService.get(uri);
}

const appointmentService = {
    get,
}

export default appointmentService;
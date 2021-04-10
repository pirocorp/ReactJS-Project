import requesterService from './requesterService';

const endpoint = '/appointments';

const get = (id) => requesterService.get(`${endpoint}/${id}`);

const updateStatus = (id, status) => requesterService.patch(`${endpoint}/${id}?status=${status}`);

const appointmentService = {
    get,
    updateStatus
}

export default appointmentService;
import requesterService from './requesterService';

const endpoint = '/slots';

const getAll = () => requesterService.get(endpoint);

const slotsService = {
    getAll,
};

export default slotsService;
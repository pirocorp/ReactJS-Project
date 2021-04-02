import requesterService from './requesterService';

const endpoint = '/specializations';

const getAll = () => requesterService.get(endpoint);

const specialitiesService = {
    getAll,
};

export default specialitiesService;
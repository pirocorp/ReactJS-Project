import apiConstants from './apiConstants';

const endpoint = apiConstants.baseUrl + '/specializations';

function getAll () {
    return fetch(endpoint)
        .then(res => res.json())
        .catch(err => console.log(err));
}

const specialitiesService = {
    getAll,
};

export default specialitiesService;
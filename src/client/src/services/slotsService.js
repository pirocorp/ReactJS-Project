import apiConstants from './apiConstants';

const endpoint = apiConstants.baseUrl + '/slots';

function getAll() {
    return fetch(endpoint)
        .then(res => res.json())
        .catch(err => console.log(err))
}

const slotsService = {
    getAll,
};

export default slotsService;
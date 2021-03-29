import apiConstants from './apiConstants';

const endpoint = apiConstants.baseUrl + '/doctors';

function getAll () {
    return fetch(endpoint)
        .then(res => res.json())
        .catch(err => console.log(err));
}

const doctorsService = {
    getAll,
};

export default doctorsService;
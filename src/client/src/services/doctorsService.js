import apiConstants from './apiConstants';

const endpoint = apiConstants.baseUrl + '/doctors';

function getAll (queryString) {
    let uri = endpoint;

    if(queryString){
        uri += queryString;
    }

    return fetch(uri)
        .then(res => res.json())
        .catch(err => console.log(err));
}

const doctorsService = {
    getAll,
};

export default doctorsService;
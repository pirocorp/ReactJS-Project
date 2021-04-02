import apiConstants from './apiConstants';

function get(endpoint) {

    const uri = apiConstants.baseUrl + endpoint;

    return fetch(uri)
        .then(res => res.json())
        .catch(err => console.log(err));
};

function generic(endpoint, method, data = {}) {
    const uri = apiConstants.baseUrl + endpoint;

    return fetch(uri, {
        method: method,
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(data)
    })
    .then(res => res.json())
    .catch(err => console.log(err));
};

const post = (endpoint, data = {}) => generic(endpoint, 'POST', data);

const put = (endpoint, data = {}) => generic(endpoint, 'PUT', data);

const patch = (endpoint, data = {}) => generic(endpoint, 'PATCH', data);

const del = (endpoint, data = {}) => generic(endpoint, 'DELETE', data);

const requester = {
    get,
    post,
    put,
    patch,
    del,
    generic
};

export default requester;
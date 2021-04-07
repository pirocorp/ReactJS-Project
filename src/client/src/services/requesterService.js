import apiConstants from './apiConstants';
import authService from './authService';

function generic(endpoint, method, data = {}) {
    const uri = apiConstants.baseUrl + endpoint;
    const jwt = authService.getToken();

    let options = {
        method: method,
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${jwt}`,
        },        
    };

    if(method !== 'GET'){
        options.body = JSON.stringify(data)
    }

    return fetch(uri, options)
        .then(res => res.json())
        .catch(err => console.log(err));
};

const get = (endpoint) => generic(endpoint, 'GET');

const post = (endpoint, data = {}) => generic(endpoint, 'POST', data);

const put = (endpoint, data = {}) => generic(endpoint, 'PUT', data);

const patch = (endpoint, data = {}) => generic(endpoint, 'PATCH', data);

const del = (endpoint, data = {}) => generic(endpoint, 'DELETE', data);

const sendData = (endpoint, method, data) => {
    const uri = apiConstants.baseUrl + endpoint;
    const jwt = authService.getToken();
    
    const formData = new FormData();

    for(const name in data) {
        formData.append(name, data[name]);
    }

    let options = {
        method: method,
        headers: {
            'Authorization': `Bearer ${jwt}`,
        },   
        body: formData     
    };

    console.log(formData);

    return fetch(uri, options)
        .then(res => res.json())
        .catch(err => console.log(err));
}

const requester = {
    get,
    post,
    put,
    patch,
    del,
    sendData,
    generic
};

export default requester;
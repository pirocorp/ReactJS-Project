import requesterService from './requesterService';

const endpoint = '/users';
const existsEndpoint = `${endpoint}/exists`;
const registerEndpoint = `${endpoint}/register`;
const loginEndpoint = `${endpoint}/login`;

const emailExists = (email) => requesterService.post(existsEndpoint, { email });

const usernameExists = (username) => requesterService.post(existsEndpoint, { username });

const register = (data) => requesterService.post(registerEndpoint, data);

const login = (data) => requesterService.post(loginEndpoint, data);

const doctorsService = {
    usernameExists,
    emailExists,
    register,
    login
};

export default doctorsService;
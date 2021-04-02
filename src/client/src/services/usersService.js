import requesterService from './requesterService';

const endpoint = '/users';
const existsSubEndpoint = `${endpoint}/exists`;

const emailExists = (email) => requesterService.post(existsSubEndpoint, { email });

const usernameExists = (username) => requesterService.post(existsSubEndpoint, { username });

const doctorsService = {
    usernameExists,
    emailExists,
};

export default doctorsService;
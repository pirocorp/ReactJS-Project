import jwt_decode from "jwt-decode";

const dataName = 'data'

function setCurrentUser(user) {
    sessionStorage.setItem(dataName, JSON.stringify(user));
}

function getCurrentUser() {
    const userString = sessionStorage.getItem(dataName);
    const user = JSON.parse(userString);

    return user;
}

function logout() {
    sessionStorage.removeItem(dataName);
}

const getToken = () => getCurrentUser()?.token;

const getRole = (token) => {
    const roleIdentifier = 'http://schemas.microsoft.com/ws/2008/06/identity/claims/role';

    if(!token) return;

    var decoded = jwt_decode(token);
    return decoded['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
}

const authService = {
    setCurrentUser,
    getCurrentUser,
    getToken,
    logout,
    getRole
}

export default authService;
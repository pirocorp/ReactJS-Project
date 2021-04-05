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

const getClaims = (token) => token ? jwt_decode(token) : null;

const getUserId = (token) => getClaims(token) ? getClaims(token)['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'] : '';

const getRole = (token) => getClaims(token) ? getClaims(token)['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] : '';

const authService = {
    setCurrentUser,
    getCurrentUser,
    getToken,
    logout,
    getRole,
    getUserId,
    getClaims
}

export default authService;
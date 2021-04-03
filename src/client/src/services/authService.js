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

const authService = {
    setCurrentUser,
    getCurrentUser,
    getToken,
    logout,
}

export default authService;
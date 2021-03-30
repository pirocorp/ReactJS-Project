function createQueryStringFromObject(obj) {
    let currentQueries = Object.entries(obj);
    let queryString = currentQueries.map(q => `${q[0]}=${q[1]}`).join('&');

    return queryString;
}

export { createQueryStringFromObject };
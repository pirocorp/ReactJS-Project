function createQueryStringFromObject(obj) {
    let currentQueries = Object.entries(obj);
    let queryString = currentQueries
        .filter(r => r[1]?.length ??  0 === 0)
        .map(q => `${q[0]}=${q[1]}`).join('&');

    return queryString;
}

export { createQueryStringFromObject };
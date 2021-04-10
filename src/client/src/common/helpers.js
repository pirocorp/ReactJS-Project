const createQueryStringFromObject = (obj) => {
    let currentQueries = Object.entries(obj);
    let queryString = currentQueries
        .filter(r => r[1]?.length ?? 0 === 0)
        .map(q => `${q[0]}=${q[1]}`).join('&');

    return queryString;
};

const convertDate = (date) => date.split('T')[0].replaceAll('-', ' ').split(' ').reverse().join(' / ');

const statusClass = (statusName) => {
    switch(statusName) {
        case "Confirmed":
            return 'bg-success-light';
        case "Canceled":
            return 'bg-danger-light';
        case "Pending":
            return 'bg-warning-light';
        case "Completed":
            return 'bg-primary-light';
    }
};

export { 
    createQueryStringFromObject,
    convertDate,
    statusClass
};
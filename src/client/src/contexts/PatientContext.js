import React from 'react';

const PatientContext = React.createContext({
    address: '',
    appointments: [],
    city: '',
    email: '',
    firstName: '',
    id: '',
    imageUrl: '',
    lastName: '',
    phone: '',
    ssn: ''
});

PatientContext.displayName = 'Patient Context';
export default PatientContext;
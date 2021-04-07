import { useEffect, useState, useContext } from 'react';
import { Redirect, Route, Switch } from 'react-router-dom';

import authService from '../../services/authService';
import usersService from '../../services/usersService';
import patientsService from '../../services/patientService';

import PatientProfile from '../PatientProfile';
import UserContext from '../../contexts/UserContext';
import PatientContext from '../../contexts/PatientContext';

import  './Patient.css';

function Patient() {    
    const [patientProfile, setPatientProfile] = useState({
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

    const { user } = useContext(UserContext);

    useEffect(() => {
        let userId = authService.getUserId(user?.token);

        usersService.getProfileId(userId)
            .then(res => patientsService.getProfile(res?.profileId))
            .then(res => setPatientProfile(res));            
    }, [user]);

    const role = authService.getRole(user.token);

    if(!user || role != 'Patient'){
        return <Redirect to="/login"/>
    }

    return(
        <Switch>
            <PatientContext.Provider value={ patientProfile }>
                <Route path="/patients/profile" exact component={ PatientProfile } />
            </PatientContext.Provider>
        </Switch>
    );
}

export default Patient;
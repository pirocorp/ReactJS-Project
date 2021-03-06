import { useEffect, useState, useContext } from 'react';
import { Redirect, Route, Switch } from 'react-router-dom';

import authService from '../../services/authService';
import usersService from '../../services/usersService';
import patientsService from '../../services/patientService';

import PatientProfile from '../PatientProfile';
import PatientDashboard from '../PatientDashboard';
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
        updatePatientProfile();
          
    }, [user]);

    const role = authService.getRole(user.token);

    const updatePatientProfile = () => {
        let userId = authService.getUserId(user?.token);
        
        console.log('update');

        usersService.getProfileId(userId)
            .then(res => patientsService.getProfile(res?.profileId))
            .then(res => setPatientProfile(res))
            .catch(res => console.log(res));  
    };

    if(!user || role != 'Patient'){
        return <Redirect to="/login"/>
    }  

    return(
        <Switch>
            <PatientContext.Provider value={ {...patientProfile, updatePatientProfile } }>
                <Route path="/patients/profile" exact component={ PatientProfile } />
                <Route path="/patients/dashboard" exact component={ PatientDashboard } />
            </PatientContext.Provider>
        </Switch>
    );
}

export default Patient;
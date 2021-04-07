import { useEffect, useState, useContext } from 'react';
import { Redirect, Route, Switch } from 'react-router-dom';

import authService from '../../services/authService';
import usersService from '../../services/usersService';
import doctorService from '../../services/doctorsService';
import patientService from '../../services/patientService';

import DoctorDashboard from '../DoctorDashboard';
import DoctorSchedule from '../DoctorSchedule';
import UserContext from '../../contexts/UserContext';

import './Doctor.css';

function Doctor() {
    const [doctorProfile, setDoctorProfile] = useState({});

    const { user } = useContext(UserContext);

    useEffect(() => {
        let userId = authService.getUserId(user?.token);

        usersService.getProfileId(userId)
            .then(res => doctorService.get(res?.profileId))
            .then(res => setDoctorProfile(res));
    }, [user]);

    const role = authService.getRole(user.token);

    if(!user || role != 'Doctor'){
        return <Redirect to="/login"/>
    }

    return(
        <Switch>
            <Route path="/doctors/dashboard" exact render={ props => <DoctorDashboard {...props} doctorProfile={ doctorProfile } /> } />
            <Route path="/doctors/shifts" exact render={ props => <DoctorSchedule {...props} doctorProfile={ doctorProfile } /> } />
        </Switch>
    );
}

export default Doctor;
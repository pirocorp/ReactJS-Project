import { Redirect, Route, Switch } from 'react-router-dom';
import { useEffect, useState } from 'react';

import authService from '../../services/authService';
import usersService from '../../services/usersService';
import doctorService from '../../services/doctorsService';

import DoctorDashboard from '../DoctorDashboard';
import DoctorSchedule from '../DoctorSchedule';

import './Doctor.css';

function Doctor({
    user
}) {
    const [doctorProfile, setDoctorProfile] = useState({});

    useEffect(() => {
        let userId = authService.getUserId(user?.token);
        usersService.getProfileId(userId)
            .then(res => doctorService.get(res?.profileId))
            .then(res => setDoctorProfile(res));
    }, []);

    if(!user){
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
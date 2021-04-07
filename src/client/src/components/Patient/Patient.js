import { useEffect, useState, useContext } from 'react';
import { Redirect, Route, Switch } from 'react-router-dom';

import authService from '../../services/authService';
import usersService from '../../services/usersService';

import PatientProfile from '../PatientProfile';
import UserContext from '../../contexts/UserContext';

import  './Patient.css';

function Patient() {
    
    const { user } = useContext(UserContext);

    const role = authService.getRole(user.token);

    if(!user || role != 'Patient'){
        return <Redirect to="/login"/>
    }

    return(
        <Switch>
            <Route path="/patients/profile" exact component={ PatientProfile } />
        </Switch>
    );
}

export default Patient;
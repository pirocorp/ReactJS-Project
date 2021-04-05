import { useEffect, useState } from 'react';

import authService from '../../services/authService';
import usersService from '../../services/usersService';
import doctorService from '../../services/doctorsService';

import DoctorPage from '../Shared/DoctorPage';

import './DoctorDashboard.css';

function DoctorDashboard({
    user
}) {

    const [doctorProfile, setDoctorProfile] = useState({});

    useEffect(() => {
        let userId = authService.getUserId(user.token);
        usersService.getProfileId(userId)
            .then(res => doctorService.get(res.profileId))
            .then(res => setDoctorProfile(res));
    }, [])

    return(
        <DoctorPage doctorProfile={ doctorProfile }>

        </DoctorPage>
    );
}

export default DoctorDashboard;
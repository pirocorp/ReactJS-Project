import { useEffect, useState } from 'react';

import doctorService from '../../services/doctorsService';

import BreadCrumbs from '../Shared/Breadcrumb';
import DoctorCard from '../Shared/DoctorCard';
import DoctorDetailsTab from './DoctorDetailsTab';

import './DoctorProfile.css';

function DoctorProfile({
    match
}) {
    const [doctor, setDoctor] = useState({});
    const doctorId = match.params.doctorId;

    useEffect(() => {
        doctorService
            .get(doctorId)
            .then(doctor => setDoctor(doctor));
    }, []);

    return (
        <>
            <BreadCrumbs active="Doctor Profile" title="Doctor Profile" />

            <div className="content">
                <div className="container">
                    <DoctorCard {...doctor} />

                    <DoctorDetailsTab />
                </div>
            </div>
        </>
    );
}

export default DoctorProfile;
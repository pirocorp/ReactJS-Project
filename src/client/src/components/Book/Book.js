import { useState, useEffect } from 'react';

import doctorService from '../../services/doctorsService';

import BreadCrumbs from '../Shared/Breadcrumb';
import DoctorBookCard from './DoctorBookCard';
import DoctorBookSchedule from './DoctorBookSchedule';

import './Book.css';

function Book({
    match
}) {
    const [doctor, setDoctor] = useState({});
    const doctorId = match.params.doctorId;

    useEffect(() => {
        doctorService
            .get(doctorId)
            .then(doctor => setDoctor(doctor));
    }, [doctorId]);

    return (
        <>
            <BreadCrumbs homeLink="/patients/search" homeName="Search" active="Book Doctor" title="Book Doctor" />

            <div className="content">
                <div className="container">

                    <div className="row">
                        <div className="col-12">
                            <DoctorBookCard { ... doctor }/>

                            <DoctorBookSchedule doctorId={ doctorId } />
                        </div>
                    </div>
                </div>

            </div>
        </>
    );
}

export default Book;
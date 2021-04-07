import { useState, useContext } from 'react';

import PatientPage from '../Shared/PatientPage';
import PatientContext from '../../contexts/PatientContext';

import patientsService from '../../services/patientService';

import './PatientProfile.css';

function PatientProfile() {

    const [imageState, setImageState] = useState();
    const [imageInputName, setImageInputName] = useState('');
    const patientProfile = useContext(PatientContext);


    const [error, setError] = useState({
        title: '',
        text: ''
    });

    const imageElement = patientProfile?.imageUrl 
        ? <img src={patientProfile?.imageUrl} alt="User Image" />
        : '';

    const onPatientProfileSubmitHandler = (e) => {
        e.preventDefault();

        const payload = {
            firstName: e.target["first-name"]?.value,
            lastName: e.target["last-name"]?.value,
            email: e.target["email"]?.value,
            phone: e.target["phone"]?.value,
            address: e.target["address"]?.value,
            city: e.target["city"]?.value,
            ssn: e.target["ssn"]?.value,
            image: imageState
        }

        // TODO: Client Side Validation and errors from the backend

        patientsService.createPatientProfile(payload);
    }

    const onImageUploadChange = (e) => {
        const file = Array.from(e.target.files)[0];

        setImageInputName(file?.name);

        setImageState(file);
    }

    return (
        <PatientPage title="Patient Profile">

            <form onSubmit={ onPatientProfileSubmitHandler }>
                <div className="row form-row">
                    <div className="col-12 col-md-12">
                        <div className="form-group">
                            <div className="change-avatar">
                                <div className="profile-img">
                                    { imageElement }
                                </div>
                                <div className="upload-img">
                                    <div className="change-photo-btn">
                                        <span><i className="fa fa-upload"></i> Upload Photo</span>
                                        <input type="file" className="upload" onChange={ onImageUploadChange }/>
                                    </div>
                                    <small className="form-text text-muted">{imageInputName ? imageInputName : 'Allowed JPG, GIF or PNG. Max size of 2MB'}</small>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div className="col-12 col-md-6">
                        <div className="form-group">
                            <label htmlFor="first-name">First Name</label>
                            <input 
                                type="text" 
                                id="first-name" 
                                name="first-name" 
                                className="form-control" 
                                placeholder="Richard" 
                                defaultValue={patientProfile.firstName} 
                            />
                        </div>
                    </div>
                    <div className="col-12 col-md-6">
                        <div className="form-group">
                            <label htmlFor="last-name">Last Name</label>
                            <input 
                                id="last-name" 
                                name="last-name" 
                                type="text" 
                                className="form-control" 
                                placeholder="Wilson" 
                                defaultValue={patientProfile.lastName}
                            />
                        </div>
                    </div>
                    <div className="col-12 col-md-6">
                        <div className="form-group">
                            <label htmlFor="email">Email</label>
                            <input 
                                id="email" 
                                name="email" 
                                type="email" 
                                className="form-control" 
                                placeholder="richard@example.com" 
                                defaultValue={patientProfile.email}
                            />
                        </div>
                    </div>
                    <div className="col-12 col-md-6">
                        <div className="form-group">
                            <label htmlFor="phone">Phone</label>
                            <input 
                                id="phone" 
                                name="phone" 
                                type="text" 
                                placeholder="+1 202-555-0125" 
                                className="form-control" 
                                defaultValue={patientProfile.phone}
                            />
                        </div>
                    </div>
                    <div className="col-12">
                        <div className="form-group">
                            <label htmlFor="address">Address</label>
                            <input 
                                id="address" 
                                name="address" 
                                type="text" 
                                className="form-control"
                                placeholder="806 Twin Willow Lane" 
                                defaultValue={patientProfile.address}
                            />
                        </div>
                    </div>
                    <div className="col-12 col-md-6">
                        <div className="form-group">
                            <label htmlFor="city">City</label>
                            <input 
                                id="city" 
                                name="city" 
                                type="text" 
                                className="form-control" 
                                placeholder="Old Forge" 
                                defaultValue={patientProfile.city}
                            />
                        </div>
                    </div>
                    <div className="col-12 col-md-6">
                        <div className="form-group">
                            <label htmlFor="ssn">SSN</label>
                            <input 
                                id="ssn" 
                                name="ssn" 
                                type="text" 
                                className="form-control" 
                                placeholder="13420"
                                defaultValue={patientProfile.ssn} 
                            />
                        </div>
                    </div>
                </div>
                <div className="submit-section">
                    <button type="submit" className="btn btn-primary submit-btn">Save Changes</button>
                </div>
            </form>
        </PatientPage>
    );
}

export default PatientProfile;
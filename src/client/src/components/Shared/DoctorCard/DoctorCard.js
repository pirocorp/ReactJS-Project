import { Link, useHistory } from 'react-router-dom';

import SpecializationIcon from './SpecializationIcon';
import Rating from '../Rating';

import './DoctorCard.css';

function DoctorCard({
    education,
    firstName,
    lastName,
    imageUrl,
    specializations,
    rating,
    ratingsCount,
    workEmail,
    workPhone,
    id
}) {
    let fullName = firstName ?? '' + ' ' + (lastName ?? '');

    let path = useHistory().location.pathname;

    return(
        <div className="card">
        <div className="card-body">
            <div className="doctor-widget">
                <div className="doc-info-left">
                    <div className="doctor-img">
                        {imageUrl ? <img src={imageUrl} className="img-fluid" alt={fullName} /> : <img src="/assets/placeholders/Profile_placeholder.png" className="img-fluid" alt="Profile image placeholder" />}
                    </div>
                    <div className="doc-info-cont">
                        <h4 className="doc-name"><a to="doctor-profile.html">Dr. {fullName}</a></h4>
                        <p className="doc-speciality">{education}</p>
                        <h5 className="doc-department">
                            {specializations?.map(s => <SpecializationIcon key={s.id} {...s} />)}
                        </h5>

                        <Rating rating={rating ?? 0} ratingsCount={ratingsCount ?? 0} />

                        <div className="clinic-details">
                            <ul className="clinic-gallery mt-4">
                                <li>
                                    <Link to="#" data-fancybox="gallery">
                                        <img src="/assets/img/features/feature-01.jpg" alt="Feature" />
                                    </Link>
                                </li>
                                <li>
                                    <Link to="#" data-fancybox="gallery">
                                        <img  src="/assets/img/features/feature-02.jpg" alt="Feature" />
                                    </Link>
                                </li>
                                <li>
                                    <Link to="#" data-fancybox="gallery">
                                        <img src="/assets/img/features/feature-03.jpg" alt="Feature" />
                                    </Link>
                                </li>
                                <li>
                                    <Link to="#" data-fancybox="gallery">
                                        <img src="/assets/img/features/feature-04.jpg" alt="Feature" />
                                    </Link>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div className="doc-info-right">
                    <div className="clini-infos">
                        <ul>
                            <li className="small"><i className="far fa-envelope"></i>{workEmail}</li>
                            <li><i className="fas fa-mobile-alt"></i>{workPhone}</li>
                        </ul>
                    </div>
                    <div className="clinic-booking">
                        { path.includes('patient') ? <Link className="view-pro-btn" to={`/doctors/profile/${id}`}>View Profile</Link> : '' }                        
                        <Link className="apt-btn" to={`/doctors/book/${id}`}>Book Appointment</Link>
                    </div>
                </div>
            </div>
        </div>
    </div>
    );
}

export default DoctorCard;
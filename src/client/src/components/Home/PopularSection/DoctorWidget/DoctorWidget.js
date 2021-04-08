import { Link } from 'react-router-dom';

import Rating from '../../../Shared/Rating';

import './DoctorWidget.css';

function DoctorWidget({
    firstName,
    lastName,
    education,
    rating,
    ratingsCount,
    imageUrl,
    id
}) {
    return (
        <div className="slick-slide" data-slick-index="2" aria-hidden="true" tabIndex="-1">
            <div className="profile-widget" /* style="width: 100%; display: inline-block;" */>
                <div className="doc-img">
                    <Link to="#" tabIndex="-1">
                        <img className="img-fluid" alt="Doctor" src={imageUrl} />
                    </Link>
                    <Link to="#" className="fav-btn" tabIndex="-1">
                        <i className="far fa-bookmark"></i>
                    </Link>
                </div>
                <div className="pro-content">
                    <h3 className="title">
                        <Link to="doctor-profile.html" tabIndex="-1">{firstName + ' ' + lastName}</Link>
                        <i className="fas fa-check-circle verified"></i>
                    </h3>
                    <p className="speciality">{education}</p>
                    
                    <Rating rating={rating} ratingsCount={ratingsCount} />

                    <ul className="available-info">
                        <li>
                            <i className="far fa-clock"></i> Available on Fri, 22 Mar
                        </li>
                    </ul>
                    <div className="row row-sm">
                        <div className="col-6">
                            <Link to={`doctors/profile/${id}`} className="btn view-btn" tabIndex="-1">View Profile</Link>
                        </div>
                        <div className="col-6">
                            <Link to={`doctors/book/${id}`} className="btn book-btn" tabIndex="-1">Book Now</Link>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    );
}

export default DoctorWidget;
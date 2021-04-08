import Rating from '../../Shared/Rating';

import './DoctorBookCard.css';

function DoctorBookCard({
    firstName,
    lastName,
    imageUrl,
    rating,
    ratingsCount,
    education
}) {

    const doctorFullName = `Dr. ${firstName} ${lastName}`;

    return (
        <div className="card">
            <div className="card-body">
                <div className="booking-doc-info">
                    <div className="booking-doc-img">
                        <img src={ imageUrl } alt={ doctorFullName } />
                    </div>
                    <div className="booking-info">
                        <h4>{ doctorFullName }</h4>

                        <Rating rating={ rating ?? 0 } ratingsCount={ ratingsCount ?? 0 } />

                        <p className="text-muted mb-0"><i className="fas fa-university" /> { education }</p>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default DoctorBookCard;
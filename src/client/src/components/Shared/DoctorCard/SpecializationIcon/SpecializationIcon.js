import './SpecializationIcon.css';

function SpecializationIcon({
    imageURL,
    name
}) {
    return(
        <div className="d-inline-block mr-3">
            <img src={imageURL} className="img-fluid" alt="Speciality" />
            {name}
        </div>
    );
}

export default SpecializationIcon;
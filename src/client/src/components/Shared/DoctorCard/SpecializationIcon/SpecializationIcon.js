import './SpecializationIcon.css';

function SpecializationIcon({
    imageURL,
    name,
    style
}) {
    return(
        <div className="d-inline-block mr-3">
            <img style={style} src={imageURL} className="img-fluid" alt="Speciality" />
            {name}
        </div>
    );
}

export default SpecializationIcon;
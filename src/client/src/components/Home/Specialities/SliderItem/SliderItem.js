import './SliderItem.css';

function SliderItem(props) {
    return (
        <div className="slick-slide slick-cloned" data-slick-index="5" aria-hidden="true" tabIndex="-1">
            <div className="speicality-item text-center">
                <div className="speicality-img">
                    <img src={props.imageURL} className="img-fluid" alt="Speciality" />
                    <span><i className="fa fa-circle" aria-hidden="true"></i></span>
                </div>
                <p>{props.name}</p>
            </div>
        </div>
    );
}

export default SliderItem;
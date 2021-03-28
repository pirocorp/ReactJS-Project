import './SliderDot.css';

function SliderDot(props) {
    return (
        <li className={props.itemIsActive(props.children - 1)} role="presentation">
            <button
                type="button"
                role="tab"
                id="slick-slide-control00"
                aria-controls="slick-slide00"
                aria-label="1 of 5"
                tabIndex="0"
                onClick={() => props.onSliderItemClick(props.children - 1)}
            >{props.children}</button>
        </li>
    );
}

export default SliderDot;
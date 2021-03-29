import './SliderDot.css';

function SliderDot({
    itemIsActive,
    onSliderDotClick,
    children
}) {
    return (
        <li className={itemIsActive(children - 1)} role="presentation">
            <button
                type="button"
                role="tab"
                id="slick-slide-control00"
                aria-controls="slick-slide00"
                aria-label="1 of 5"
                tabIndex="0"
                onClick={() => onSliderDotClick(children - 1)}
            >{children}</button>
        </li>
    );
}

export default SliderDot;
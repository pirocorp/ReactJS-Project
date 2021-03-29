import SliderDot from './SliderDot'

function SliderDotsControl({
    sliderButtonsCount,
    onSliderDotClick,
    itemIsActive
}) {
    return (
        <ul className="slick-dots" role="tablist">
            {sliderButtonsCount > 0
                ? [...Array(sliderButtonsCount)]
                    .map((e, i) => <SliderDot
                        key={i}
                        onSliderDotClick={onSliderDotClick}
                        itemIsActive={itemIsActive}
                    >{i + 1}</SliderDot>)
                : []}
        </ul>
    );
}

export default SliderDotsControl;
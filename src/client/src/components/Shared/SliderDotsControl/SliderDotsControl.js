import SliderDot from './SliderDot'

function SliderDotsControl(props) {
    return (
        <ul className="slick-dots" role="tablist">
            {props.sliderButtonsCount > 0
                ? [...Array(props.sliderButtonsCount)]
                    .map((e, i) => <SliderDot
                        key={i}
                        onSliderItemClick={props.onSliderItemClick}
                        itemIsActive={props.itemIsActive}
                    >{i + 1}</SliderDot>)
                : []}
        </ul>
    );
}

export default SliderDotsControl;
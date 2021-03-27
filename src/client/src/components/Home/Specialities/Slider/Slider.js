import { Component } from 'react';

import SliderButton from '../SliderButton'

import './Slider.css';

class Slider extends Component {
    constructor(props){
        super(props);

        this.state = {
            offset: 0
        }

        this.sliderSize = 7;
        this.onSliderItemClick = this.onSliderItemClick.bind(this);
        this.itemIsActive = this.itemIsActive.bind(this);
    }

    onSliderItemClick(newOffset) {
        this.setState((oldState) => oldState.offset = newOffset);
    }

    itemIsActive(offsetButton) {
        if(this.state.offset === offsetButton){
            return 'slick-active';
        }

        return '';
    }

    render(){
        const sliderButtonsCount = this.props.children.length - this.sliderSize + 1;

        return (
            <div className="specialities-slider slider slick-initialized slick-slider slick-dotted">
                <div className="slick-track draggable">
                    {this.props.children.slice(this.state.offset, this.state.offset + this.sliderSize)}
                </div>
                <ul className="slick-dots" role="tablist">
                    {sliderButtonsCount > 0 
                        ? [...Array(sliderButtonsCount)]
                            .map((e, i) => <SliderButton 
                                                key={i} 
                                                onSliderItemClick={this.onSliderItemClick} 
                                                itemIsActive={this.itemIsActive}
                                            >{i + 1}</SliderButton>)
                        : []}
                </ul>
            </div>
        );
    }
}

export default Slider;
import { Component } from 'react';

import SliderDotsControl from '../SliderDotsControl'

import './Slider.css';

class Slider extends Component {
    constructor(props) {
        super(props);

        this.state = {
            offset: 0
        }

        this.sliderSize = props.sliderSize;
        this.onSliderItemClick = this.onSliderItemClick.bind(this);
        this.itemIsActive = this.itemIsActive.bind(this);
    }

    onSliderItemClick(newOffset) {
        this.setState((oldState) => oldState.offset = newOffset);
    }

    itemIsActive(offsetButton) {
        if (this.state.offset === offsetButton) {
            return 'slick-active';
        }

        return '';
    }

    render() {
        const sliderButtonsCount = this.props.children.length - this.sliderSize + 1;

        let classes = ["slider", "slick-initialized", "slick-slider"];
        classes.push(this.props.className);

        let control;

        if(this.props.className.includes('slick-dotted')) {
            control = <SliderDotsControl 
                          sliderButtonsCount={sliderButtonsCount}
                          onSliderItemClick={this.onSliderItemClick}
                          itemIsActive={this.itemIsActive}
                      />
        }

        return (
            <div className={classes.join(' ')}>
                <div className="slick-track draggable">
                    {this.props.children.slice(this.state.offset, this.state.offset + this.sliderSize)}
                </div>
                {control}    
            </div>
        );
    }
}

export default Slider;
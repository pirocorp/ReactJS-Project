import { Component } from 'react';

import SliderDotsControl from '../SliderDotsControl';

import { PrevArrow, NextArrow } from '../SliderArrowsControl/SliderArrowsControl';

import './Slider.css';

class Slider extends Component {
    constructor(props) {
        super(props);

        this.state = {
            offset: 0
        }

        this.sliderSize = props.sliderSize;
        this.onSliderDotClick = this.onSliderDotClick.bind(this);
        this.onArrowClick = this.onArrowClick.bind(this);
        this.itemIsActive = this.itemIsActive.bind(this);
    }

    onSliderDotClick(newOffset) {
        this.setState((oldState) => oldState.offset = newOffset);
    }

    onArrowClick(offsetChange) {
        let newOffset =  Math.min(Math.max(0, this.state.offset + offsetChange), (this.props.children.length - this.sliderSize));
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
        let prevArrow, nextArrow;

        if(this.props.className.includes('slick-dotted')) {
            control = <SliderDotsControl 
                          sliderButtonsCount={sliderButtonsCount}
                          onSliderDotClick={this.onSliderDotClick}
                          itemIsActive={this.itemIsActive}
                      />
        } else {
            prevArrow = <PrevArrow onArrowClick={this.onArrowClick} />
            nextArrow = <NextArrow onArrowClick={this.onArrowClick} />
        }

        let elements = this.props.children.slice(this.state.offset, this.state.offset + this.sliderSize);

        console.log(this.props.children);

        return (
            <div className={classes.join(' ')}>
                { prevArrow }
                <div className="slick-list draggable">
                    <div className="slick-track"> 
                        {elements}
                    </div>
                </div>
                { control }   
                { nextArrow } 
            </div>
        );
    }
}

export default Slider;
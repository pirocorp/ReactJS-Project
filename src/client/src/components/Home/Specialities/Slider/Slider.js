import { Component } from 'react';

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
        return (
            <div className="specialities-slider slider slick-initialized slick-slider slick-dotted">
                <div className="slick-track draggable">
                    {this.props.children.slice(this.state.offset, this.state.offset + this.sliderSize)}
                </div>
                <ul className="slick-dots" role="tablist">
                    <li className={this.itemIsActive(0)} role="presentation">
                        <button
                            type="button"
                            role="tab"
                            id="slick-slide-control00"
                            aria-controls="slick-slide00"
                            aria-label="1 of 5"
                            tabIndex="0"
                            onClick={() => this.onSliderItemClick(0)}
                        >1</button>
                    </li>
                    <li role="presentation" className={this.itemIsActive(1)}>
                        <button
                            type="button"
                            role="tab"
                            id="slick-slide-control01"
                            aria-controls="slick-slide01"
                            aria-label="2 of 5"
                            tabIndex="-1"
                            onClick={() => this.onSliderItemClick(1)}
                        >2</button>
                    </li>
                    <li role="presentation" className={this.itemIsActive(2)}>
                        <button
                            type="button"
                            role="tab"
                            id="slick-slide-control02"
                            aria-controls="slick-slide02"
                            aria-label="3 of 5"
                            tabIndex="-1"
                            onClick={() => this.onSliderItemClick(2)}
                        >3</button>
                    </li>
                    <li role="presentation" className={this.itemIsActive(3)}>
                        <button
                            type="button"
                            role="tab"
                            id="slick-slide-control03"
                            aria-controls="slick-slide03"
                            aria-label="4 of 5"
                            tabIndex="-1"
                            onClick={() => this.onSliderItemClick(3)}
                        >4</button>
                    </li>
                    <li role="presentation" className={this.itemIsActive(4)}>
                        <button
                            type="button"
                            role="tab"
                            id="slick-slide-control04"
                            aria-controls="slick-slide04"
                            aria-label="5 of 5"
                            tabIndex="-1"
                            onClick={() => this.onSliderItemClick(4)}
                        >5</button>
                    </li>
                </ul>
            </div>
        );
    }
}

export default Slider;
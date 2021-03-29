function PrevArrow({
    onArrowClick
}) {
    return(
        <button className="slick-prev slick-arrow" aria-label="Previous" type="button" onClick={() => onArrowClick(-1)}>Previous</button>
    );
}

function NextArrow({
    onArrowClick
}) {
    return(
        <button className="slick-next slick-arrow" aria-label="Next" type="button" onClick={() => onArrowClick(1)}>Next</button>        
    );
}

export { PrevArrow, NextArrow };
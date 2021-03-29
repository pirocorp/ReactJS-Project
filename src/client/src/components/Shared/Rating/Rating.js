import './Rating.css';

function Rating({
    rating,
    ratingsCount
}) {
    const filled = Math.round(rating);
    const empty = 5 - filled;

    return(
        <div className="rating">
            {
                [...Array(filled)]
                    .map((e, i) => <i key={i} className="fas fa-star filled"></i>)
            }
            {
                [...Array(empty)]
                    .map((e, i) => <i key={ filled + 1 + i } className="fas fa-star"></i>)
            }
            <span className="d-inline-block average-rating">({ratingsCount})</span>
        </div> 
    );
}

export default Rating;
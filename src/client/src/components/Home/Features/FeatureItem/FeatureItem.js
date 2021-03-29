import './FeatureItem.css';

function FeatureItem({
    title,
    imageURL
}) {
    return(
        <div className="feature-item text-center">
            <img src={ imageURL } className="img-fluid" alt={ title } />
            <p>{ title }</p>
        </div>
    );
}

export default FeatureItem;
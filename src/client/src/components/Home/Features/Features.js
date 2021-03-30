import FeatureItem from './FeatureItem/FeatureItem';
import './Features.css';

function Features() {
    let features = [
        { title: "Patient Ward", imageURL : "/assets/img/features/feature-01.jpg"},
        { title: "Test Room", imageURL : "/assets/img/features/feature-02.jpg"},
        { title: "ICU", imageURL : "/assets/img/features/feature-03.jpg"},
        { title: "Laboratory", imageURL : "/assets/img/features/feature-04.jpg"},
        { title: "Operation", imageURL : "/assets/img/features/feature-05.jpg"},
        { title: "Medical", imageURL : "/assets/img/features/feature-06.jpg"},
    ];

    return(
        <section className="section section-features">
				<div className="container-fluid">
				   <div className="row">
						<div className="col-md-5 features-img">
							<img src="/assets/img/features/feature.png" className="img-fluid" alt="Feature" />
						</div>
						<div className="col-md-7">
							<div className="section-header">	
								<h2 className="mt-2">Availabe Features in Our Clinic</h2>
								<p>It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. </p>
							</div>	
							<div className="features-container">
                                {features.map(f => <FeatureItem key={f.imageURL} title={f.title} imageURL={f.imageURL} /> )}
							</div>
						</div>
				   </div>
				</div>
			</section>
    );
}

export default Features;
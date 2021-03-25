import Slider from './Slider';
import SliderItem from './SliderItem';

import './Specialities.css';

function Specialities() {
    const specialities = [
        {index: 1, title: "Urology", imageURL: "/assets/img/specialities/specialities-01.png"},
        {index: 2, title: "Neurology", imageURL: "/assets/img/specialities/specialities-02.png"},
        {index: 3, title: "Orthopedic", imageURL: "/assets/img/specialities/specialities-03.png"},
        {index: 4, title: "Cardiologist", imageURL: "/assets/img/specialities/specialities-04.png"},
        {index: 5, title: "Dentist", imageURL: "/assets/img/specialities/specialities-05.png"},
        {index: 6, title: "Surgeon", imageURL: "/assets/img/specialities/specialities-06.png"},
        {index: 7, title: "GP", imageURL: "/assets/img/specialities/specialities-07.png"},
        {index: 8, title: "Urology", imageURL: "/assets/img/specialities/specialities-01.png"},
        {index: 9, title: "Neurology", imageURL: "/assets/img/specialities/specialities-02.png"},
        {index: 10, title: "Orthopedic", imageURL: "/assets/img/specialities/specialities-03.png"},
        {index: 11, title: "Cardiologist", imageURL: "/assets/img/specialities/specialities-04.png"},
    ];

    return (
        <section className="section section-specialities">
            <div className="container-fluid">
                <div className="section-header text-center">
                    <h2>Clinic and Specialities</h2>
                    <p className="sub-title">Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p>
                </div>
                <div className="row justify-content-center">
                    <div className="col-md-9">
                        <Slider>
                            {specialities.map(x => <SliderItem key={x.index} {...x}></SliderItem>)}
                        </Slider>
                    </div>
                </div>
            </div>
        </section>
    );
}

export default Specialities;
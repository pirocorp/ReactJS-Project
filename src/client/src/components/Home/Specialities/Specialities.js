import { useEffect, useState } from 'react';

import specialitiesService from '../../../services/specialitiesService';

import Slider from '../../Shared/Slider';
import SpecialityItem from './SpecialityItem';

import './Specialities.css';

function Specialities() {
    let [specialities, setSpecialities] = useState([]);

    useEffect(() => {
        specialitiesService.getAll()
            .then(res => setSpecialities(res ?? []))
            .catch(err => { setSpecialities([]); console.log(err)});
    }, []);   

    return (
        <section className="section section-specialities">
            <div className="container-fluid">
                <div className="section-header text-center">
                    <h2>Clinic and Specialities</h2>
                    <p className="sub-title">Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p>
                </div>
                <div className="row justify-content-center">
                    <div className="col-md-9">
                        <Slider sliderSize={7} className="specialities-slider slick-dotted">
                            {specialities.map(x => <SpecialityItem key={x.id} {...x}></SpecialityItem>)}
                        </Slider>
                    </div>
                </div>
            </div>
        </section>
    );
}

export default Specialities;
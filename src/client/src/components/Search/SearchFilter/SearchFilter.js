import { useEffect, useState } from 'react';
import DatePicker from "react-datepicker";

import { createQueryStringFromObject } from '../../../common/helpers';

import specialitiesService from '../../../services/specialitiesService';

import "react-datepicker/dist/react-datepicker.css";
import './SearchFilter.css';

function SearchFilter({
    queries,
    history
}) {
    const [specialities, setSpecialities] = useState([]);
    const [date, setDate] = useState();

    useEffect(() => {
        specialitiesService
            .getAll()
            .then(r => {
                r?.unshift({ id: 'all', name: 'All' });
                setSpecialities(r);
            });
    }, []);

    function onFilterSearchSubmit(e) {
        e.preventDefault();

        queries.speciality = e.target.speciality.value;
        queries.searchTerm = e.target.searchTerm.value;  
        queries.date = date ? date.toJSON() : '';   
               
        let queryString = createQueryStringFromObject(queries);

        let url = queryString.length > 0
            ? '/patients/search?' + queryString
            : '/patients/search'
        
        history.push(url);
    }

    return (
        <div className="card search-filter">
            <div className="card-header">
                <h4 className="card-title mb-0">Search Filter</h4>
            </div>
            <div className="card-body">
                <form onSubmit={onFilterSearchSubmit}>
                    <div className="filter-widget">
                        <div className="cal-icon">
                            <DatePicker 
                                className="form-control" 
                                placeholderText="Select Date"
                                selected={date}
                                onChange={date => setDate(date)} 
                                dateFormat="yyyy/MM/dd"
                            />
                        </div>
                    </div>
                    <div className="filter-widget">
                        <h4>Select Specialist</h4>

                        <div className="form-group search-location">
                            <select
                                className="form-control pl-5"
                                placeholder="Speciality"
                                name="speciality"
                                id="speciality"
                                defaultValue={queries.speciality}
                            >
                                {specialities.map(x => <option key={x.id} value={x.id}>{x.name}</option>)}
                            </select>
                        </div>
                    </div>
                    <div className="filter-widget">
                        <h4>Doctor's Name</h4>

                        <div className="form-group search-info">
                            <input
                                type="text"
                                className="form-control pl-5"
                                placeholder="House"
                                name="searchTerm"
                                id="searchTerm"
                                defaultValue={queries.searchTerm}
                            />
                        </div>
                    </div>
                    <div className="btn-search">
                        <button className="btn btn-block">Search</button>
                    </div>

                </form>

            </div>
        </div>
    );
}

export default SearchFilter;
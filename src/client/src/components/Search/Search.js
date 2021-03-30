import queryString from 'query-string';
import { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';

import doctorsService from '../../services/doctorsService';
import Breadcrumb from './Breadcrumb/Breadcrumb';
import DoctorCard from './DoctorCard/DoctorCard';

import './Search.css';
import SearchFilter from './SearchFilter/SearchFilter';

function Search({ 
    location,
    history
 }) {
    const parsed = queryString.parse(location.search);

    let [doctors, setDoctors] = useState([]);
    let [total, setTotal] = useState(0);
    let [queries, setQueries] = useState({
        speciality: parsed.speciality,
        searchTerm: parsed.searchTerm,
        page: parsed.page ?? 1
    });

    useEffect(() => {
        doctorsService.getAll(location.search)
            .then(res => {
                setDoctors(res.results ?? []);
                setTotal(res.total);
            })
            .catch(err => { setDoctors([]); console.log(err)});
    }, [location.search]); 

    return(
        <>
            <Breadcrumb total={total} speciality={queries.speciality}/>
            <div className="content">
				<div className="container-fluid">
                    <div className="row">

                        <div className="col-md-12 col-lg-4 col-xl-3 theiaStickySidebar">
                            <SearchFilter queries={ queries } history={history} />
                        </div>

                        <div className="col-md-12 col-lg-8 col-xl-9">
                            { doctors.map(d => <DoctorCard key={d.id} {...d}/>) }
                            
                            <div className="load-more text-center">
                                <Link className="btn btn-primary btn-sm" to="#">Load More</Link>	
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </>
    );
}

export default Search;
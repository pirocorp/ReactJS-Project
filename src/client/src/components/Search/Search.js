import queryString from 'query-string';
import { useEffect, useState } from 'react';

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
    let [page, setPage] = useState(1);

    let queries = {
        speciality: parsed.speciality,
        searchTerm: parsed.searchTerm,
        date: parsed.date,      
    };

    useEffect(() => {
        doctorsService.getAll(location.search)
            .then(res => {
                setDoctors(res.results ?? []);
                setTotal(res.total);
            })
            .catch(err => { setDoctors([]); console.log(err)});
    }, [location.search]); 

    function onLoadMoreClickHandler() {
        let newPage = page + 1;      

        let url = location.search + `&page=${newPage}`;

        doctorsService.getAll(url)
            .then(res => {
                if(res.results.length === 0){
                    return
                }

                doctors.push(...res.results);
                setDoctors(doctors);
                setTotal(res.total)
                setPage(newPage);
            })
            .catch(err => console.log(err));
    }

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
                                <button className="btn btn-primary btn-sm" onClick={onLoadMoreClickHandler}>Load More</button>	
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </>
    );
}

export default Search;
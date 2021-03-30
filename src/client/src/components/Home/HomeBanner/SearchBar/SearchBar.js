import { Component } from 'react';

import specialitiesService from '../../../../services/specialitiesService.js';

import './SearchBar.css';

class SearchBar extends Component {
    constructor(props){
        super(props);

        this.state = {
            data: [{id: 'all', name: 'All'}],
            speciality: 'all',
            searchTerm: '',
        }

        this.onChangeHandler = this.onChangeHandler.bind(this);
        this.onSubmitHandler = this.onSubmitHandler.bind(this);
    }

    componentDidMount() {
        specialitiesService
            .getAll()
            .then(r => {
                r?.unshift({id: 'all', name: 'All'}); 
                this.setState(state => state.data = r)
            });
    }

    render() {
        return(
            <div className="search-box">
                <form onSubmit={this.onSubmitHandler}>
                    <div className="form-group search-location">
                        <select 
                            className="form-control" 
                            placeholder="Speciality"
                            name="speciality"
                            id="speciality"
                            value={this.state.speciality}
                            onChange={this.onChangeHandler}
                        >
                            {this.state.data.map(x => <option key={x.id} value={x.id}>{x.name}</option>)}
                        </select>
                        <span className="form-text">Select Speciality</span>
                    </div>
                    <div className="form-group search-info">
                        <input 
                            type="text" 
                            className="form-control" 
                            placeholder="House" 
                            name="searchTerm"
                            id="searchTerm"
                            value={this.state.searchTerm}
                            onChange={this.onChangeHandler}
                        />
                        <span className="form-text">Ex : Dr. House</span>
                    </div>
                    <button type="submit" className="btn btn-primary search-btn"><i className="fas fa-search"></i> <span>Search</span></button>
                </form>
            </div>
        );
    }

    onChangeHandler(e) {     
        /* [propName] - Dynamic property in object */   
        this.setState({[e.target.name]: e.target.value});
    };

    onSubmitHandler(e) {
        e.preventDefault();

        let speciality = this.state.speciality;
        let searchTerm = this.state.searchTerm;

        let queryString;

        if(speciality || searchTerm) {
            queryString = '?';

            let queries = [];

            if(speciality) {
                queries.push(`speciality=${speciality}`);
            }

            if(searchTerm) {
                queries.push(`searchTerm=${searchTerm}`);
            }

            queryString += queries.join('&');
        }
               
        let uri = encodeURI(`/patients/search${queryString}`);
        this.props.history.push(uri);
    }
}

export default SearchBar;
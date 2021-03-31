import { useState } from 'react';

import { Link, useHistory } from 'react-router-dom';

import { routes } from '../../../../../common/applicationRoutes';

import './MenuNavigation.css';

const MenuNavigation = () => {

    const[currentPath, setPath] = useState(useHistory().location.pathname);

    const setClassName = (path) => {
        if (currentPath.startsWith(path) && path.length > 1) {
            return 'active';
        } else if (currentPath === path){
            return 'active';
        }

        return '';
    };

    function onNavigationMenuClickHandler(){
        const path = window.location.pathname;

        setPath(path);
    };

    return(
        <ul className="main-nav" onClick={onNavigationMenuClickHandler}>
            <li className={setClassName('/')}>
                <Link to="/">Home</Link>
            </li>
            <li className={setClassName('/doctors') + " has-submenu"}>
                <Link to="#">Doctors <i className="fas fa-chevron-down"></i></Link>
                <ul className="submenu">
                    { routes.doctors.map(d => <li key={d.path}><Link to={d.path}>{d.title}</Link></li>) }
                </ul>
            </li>
            <li className={setClassName('/patients') + " has-submenu"}>
                <Link to="#">Patients <i className="fas fa-chevron-down"></i></Link>
                <ul className="submenu">
                    { routes.patients.map(d => <li key={d.path}><Link to={d.path}>{d.title}</Link></li>) }
                </ul>
            </li>
            <li className={setClassName('/admin')}>
                { routes.admin.map(d => <li key={d.path}><Link to={d.path}>{d.title}</Link></li>) }
            </li>
            <li className="login-link">
                <Link to="/login">Login / Signup</Link>
            </li>
        </ul>
    );
}

export default MenuNavigation;
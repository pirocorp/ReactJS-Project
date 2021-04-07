import { useState } from 'react';
import { Redirect, Route, Switch } from 'react-router-dom';

import useUser from './hooks/useUser';
import UserContext from './contexts/UserContext';
import MobileMenuContext from './contexts/MobileMenuContext';

import Header from './components/Header';
import Footer from './components/Footer';
import Home from './components/Home';
import Search from './components/Search';
import DoctorProfile from './components/DoctorProfile';
import Login from './components/Login';
import Register from './components/Register';
import Doctor from './components/Doctor';
import Patient from './components/Patient';

import './App.css';
import TestComponent from './components/TestComponents';

function App() {
    const [openMenu, setOpenMenu] = useState(false);
    const [user, setUser] = useUser();

    const userContext = {
        user: user,
        setUser: setUser,        
    };

    const mobileMenuContext = {
        openMenu: openMenu,
        setOpenMenu: setOpenMenu
    };

    return (
        <div className={ openMenu ? "menu-opened" : '' }>
            <UserContext.Provider value={ userContext }>
                <MobileMenuContext.Provider value={ mobileMenuContext }>
                    <Header />
                </MobileMenuContext.Provider>
                <Switch>
                    <Route path="/test" exact component={ TestComponent } />
                    <Route path="/" exact component={ Home } />
                    <Route path="/patients/search" exact component={ Search } />
                    <Route path="/login" exact component={ Login } />
                    <Route path="/register" exact component={ Register } />
                    <Route path="/logout" exact render={ () => <Redirect to="/" /> }/>
                    <Route path="/doctors/profile/:doctorId" exact component={ DoctorProfile } />
                    <Route path="/doctors" component={ Doctor } />
                    <Route path="/patients" component={ Patient } />
                </Switch>
                <Footer />
            </UserContext.Provider>
        </div>
    );
}

export default App;

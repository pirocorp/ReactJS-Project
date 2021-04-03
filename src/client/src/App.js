import { useState } from 'react';
import { Route, Switch } from 'react-router-dom';
import useUser from './hooks/useUser';

import Header from './components/Header';
import Footer from './components/Footer';
import Home from './components/Home';
import Search from './components/Search';
import DoctorProfile from './components/DoctorProfile';
import Login from './components/Login';
import Register from './components/Register';

import './App.css';
import TestComponent from './components/TestComponents';

function App() {
    const [openMenu, setOpenMenu] = useState(false);
    const [user, setUser] = useUser();

    return (
        <div className={openMenu ? "menu-opened" : ''}>
            <Header setOpenMenu={setOpenMenu} user={ user } setUser={ setUser }/>
            <Switch>
                <Route path="/test" exact component={ TestComponent } />
                <Route path="/" exact component={ Home } />
                <Route path="/patients/search" exact component={ Search } />
                <Route path="/login" exact render={ props => <Login {...props} setUser={ setUser } /> } />
                <Route path="/register" exact render={ props => <Register {...props} setUser={ setUser } /> } />
                <Route path="/doctors/:doctorId" exact component={ DoctorProfile } />
            </Switch>
            <Footer />
        </div>
    );
}

export default App;

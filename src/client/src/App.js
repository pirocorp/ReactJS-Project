import { Route, Switch, withRouter } from 'react-router-dom';

import Header from './components/Header';
import Footer from './components/Footer';
import Home from './components/Home';
import Search from './components/Search';

import './App.css';
import TestComponent from './components/TestComponents';

function App() {  
    const HeaderWithRouter = withRouter(Header);
    
    return (
        <>
            <HeaderWithRouter />
            <Switch>
                <Route path="/test" exact component={ TestComponent } />
                <Route path="/" exact component={ Home } />
                <Route path="/patients/search" exact component={ Search } />
            </Switch>
            <Footer />
        </>
    );
}

export default App;

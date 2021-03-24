import { Route, Switch, withRouter } from 'react-router-dom';

import Header from './components/Header';
import Footer from './components/Footer';

import './App.css';
import TestComponent from './components/TestComponents';

function App() {  
    const HeaderWithRouter = withRouter(Header);
    
    return (
        <>
            <HeaderWithRouter />
            <Switch>
                <Route path="/test" component={ TestComponent }/>
            </Switch>
            <Footer />
        </>
    );
}

export default App;

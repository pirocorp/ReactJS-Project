import { Route, Switch, withRouter } from 'react-router-dom';

import Header from './components/Header';

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
        </>
    );
}

export default App;

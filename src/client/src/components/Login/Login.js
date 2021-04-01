import { useState } from 'react';
import { Link } from 'react-router-dom';

import IsFocused from '../../hocs/IsFocused';

import './Login.css';

function Login({
    isFocused,
    onInputBlurHandler
}) {
    // TODO: Implement actual login logic and redirect to home after login

    const [state, setState] = useState({
        username : '',
        password: ''
    });

    return (
        <div className="content content-login">
            <div className="container-fluid">

                <div className="row">
                    <div className="col-md-8 offset-md-2">

                        <div className="account-content">
                            <div className="row align-items-center justify-content-center">
                                <div className="col-md-7 col-lg-6 login-left">
                                    <img src="/assets/img/login-banner.png" className="img-fluid" alt="Doccure Login" />
                                </div>
                                <div className="col-md-12 col-lg-6 login-right">
                                    <div className="login-header">
                                        <h3>Login <span>Doccure</span></h3>
                                    </div>
                                    <form action="https://dreamguys.co.in/demo/doccure/index.html">
                                        <div className={`form-group form-focus ${isFocused(state.username)}`}>
                                            <input type="email" className="form-control floating" name="username" onBlur={ (e) => onInputBlurHandler(e, setState) } />
                                            <label className="focus-label">Username</label>
                                        </div>
                                        <div className={`form-group form-focus ${isFocused(state.password)}`}>
                                            <input type="password" className="form-control floating" name="password" onBlur={ (e) => onInputBlurHandler(e, setState) }/>
                                            <label className="focus-label">Password</label>
                                        </div>
                                        <button className="btn btn-primary btn-block btn-lg login-btn" type="submit">Login</button>

                                        <div className="text-center dont-have">Don’t have an account? 
                                            <Link to="/register"> Register</Link>
                                        </div>
                                    </form>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>

            </div>

        </div>
    );
}

export default IsFocused(Login);
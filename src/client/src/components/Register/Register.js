import { useState } from 'react';

import { Link } from 'react-router-dom';
import IsFocused from '../../hocs/IsFocused';

import './Register.css';

function Register({
    isFocused,
    onInputBlurHandler
}) {

    // TODO: Implement register functionality, automatic login after register and redirect to home.

    const [state, setState] = useState({
        username : '',
        email: '',
        password: '',
        confirmPassword: ''
    });

    function onRegisterFormSubmitHandler(e) {
        e.preventDefault();

        const payload = {
            username: state.username,
            email: state.email,
            password: state.password,
        }

        console.log(payload);
    };

    return (
        <div className="content content-login">
            <div className="container-fluid">

                <div className="row">
                    <div className="col-md-8 offset-md-2">

                        <div className="account-content">
                            <div className="row align-items-center justify-content-center">
                                <div className="col-md-7 col-lg-6 login-left">
                                    <img src="assets/img/login-banner.png" className="img-fluid" alt="Doccure Register" />
                                </div>
                                <div className="col-md-12 col-lg-6 login-right">
                                    <div className="login-header">
                                        <h3>Patient Register </h3>
                                    </div>

                                    <form onSubmit={ onRegisterFormSubmitHandler }>
                                        <div className={ `form-group form-focus ${isFocused(state.username)}` }>
                                            <input type="text" className="form-control floating " name="username" onBlur={ (e) => onInputBlurHandler(e, setState) } />
                                            <label className="focus-label">Username</label>
                                        </div>
                                        <div className={ `form-group form-focus ${isFocused(state.email)}` }>
                                            <input type="email" className="form-control floating" name="email" onBlur={ (e) => onInputBlurHandler(e, setState) } />
                                            <label className="focus-label" >Email</label>
                                        </div>
                                        <div className={ `form-group form-focus ${isFocused(state.password)}` }>
                                            <input type="password" className="form-control floating" name="password" onBlur={ (e) => onInputBlurHandler(e, setState) } />
                                            <label className="focus-label">Password</label>
                                        </div>
                                        <div className={ `form-group form-focus ${isFocused(state.confirmPassword)}` }>
                                            <input type="password" className="form-control floating" name="confirmPassword" onBlur={ (e) => onInputBlurHandler(e, setState) } />
                                            <label className="focus-label">Confirm Password</label>
                                        </div>
                                        <div className="text-right">
                                            <Link className="forgot-link" to="/login">Already have an account?</Link>
                                        </div>

                                        <button className="btn btn-primary btn-block btn-lg login-btn" type="submit">Signup</button>

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

export default IsFocused(Register);
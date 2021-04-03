import { useState } from 'react';

import { Link } from 'react-router-dom';
import IsFocused from '../../hocs/IsFocused';

import Alert from '../Shared/Alert';

import userService from '../../services/usersService';

import './Register.css';

function Register({
    isFocused,
    onInputBlurHandler,
    setUser,
    history
}) {

    // TODO: Implement register functionality, automatic login after register and redirect to home.
    const [state, setState] = useState({
        username : '',
        email: '',
        password: '',
        confirmPassword: ''
    });

    const [error, setError] = useState({
        title: '',
        text: ''
    });

    async function onRegisterFormSubmitHandler(e) {
        e.preventDefault();

        if((await userService.usernameExists(state.username)).exists){
            setError({
                title: 'Username',
                text: 'is already taken'
            });

            return;
        }    
        
        if((await userService.emailExists(state.email)).exists) {
            setError({
                title: 'Email',
                text: 'is already taken'
            });

            return;
        }

        if(state.password != state.confirmPassword) {
            setError({
                title: 'Passwords',
                text: 'did not match'
            });

            return;
        }

        if(state.password.length < 6){
            setError({
                title: 'Password',
                text: 'must be at least 6 characters long'
            });

            return;
        }

        const payload = {
            username: state.username,
            email: state.email,
            password: state.password,
        };

        userService.register(payload)
            .then(res => {
                if(res.result.succeeded) {   
                    setUser(res.user);
                    history.push('/');
                    return;
                } else {
                    setError({
                        title: res.code,
                        text: res.description
                    })
                }              
            })
            .catch(res => setError({
                title: 'Unsuccessful',
                text: 'something went wrong please try again later'
            }));
    };

    function onRegisterInputBlurHandler(e) {
        onInputBlurHandler(e, setState);
    }

    function onCloseErrorAlertHandler() {
        setError({
            title: '',
            text: ''
        });
    }

    return (        
        <div className="content content-login">
            <div className="container-fluid">

                <Alert title={error.title} className="alert-danger" text={error.text} onCloseAlert={onCloseErrorAlertHandler} />

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
                                            <input type="text" className="form-control floating " name="username" onBlur={ onRegisterInputBlurHandler } />
                                            <label className="focus-label">Username</label>
                                        </div>
                                        <div className={ `form-group form-focus ${isFocused(state.email)}` }>
                                            <input type="email" className="form-control floating" name="email" onBlur={ onRegisterInputBlurHandler } />
                                            <label className="focus-label" >Email</label>
                                        </div>
                                        <div className={ `form-group form-focus ${isFocused(state.password)}` }>
                                            <input type="password" className="form-control floating" name="password" onBlur={ onRegisterInputBlurHandler } />
                                            <label className="focus-label">Password</label>
                                        </div>
                                        <div className={ `form-group form-focus ${isFocused(state.confirmPassword)}` }>
                                            <input type="password" className="form-control floating" name="confirmPassword" onBlur={ onRegisterInputBlurHandler } />
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
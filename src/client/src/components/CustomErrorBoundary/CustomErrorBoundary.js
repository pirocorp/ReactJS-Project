import React from 'react';
import { Link } from 'react-router-dom';
import { withRouter } from "react-router";

import './CustomErrorBoundary.css';

class CustomErrorBoundary extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            hasError: false,
        };

        const { history } = this.props;

        history.listen((location, action) => {
            if (this.state.hasError) {
                this.setState({
                    hasError: false,
                });
            }
        });
    }

    static getDerivedStateFromError(error) {
        return {
            hasError: true
        }
    };

    componentDidCatch(error, errorInfo) {
        console.log(error);
        console.log(errorInfo);
    };

    render() {
        if (this.state.hasError) {
            return (
                <div className="main-wrapper error-page">

                    <div className="error-box">
                        <h1>404</h1>
                        <h3 className="h2 mb-3"><i class="fas fa-exclamation-triangle"></i> Oops! Page not found!</h3>
                        <p className="h4 font-weight-normal">The page you requested was not found.</p>
                        <Link to="/" className="btn btn-primary">Back to Home</Link>
                    </div>

                </div>
            );
        }

        return this.props.children;
    };
}

export default withRouter(CustomErrorBoundary);
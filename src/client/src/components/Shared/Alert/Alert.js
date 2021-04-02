import { useEffect, useState } from 'react';

import './Alert.css';

function Alert({
    className,
    onCloseAlert,
    title,
    text
}) {
    
    const [state, setState] = useState({});

    useEffect(() => {
        setState({
            title,
            text
        })
    }, [title, text])

    function onCloseAlertHandler(e) {
        setState({})

        if(onCloseAlert && {}.toString.call(onCloseAlert) === '[object Function]') {
            onCloseAlert();
        }       
    }

    let alert = state.title || state.text
        ? (<div className={`alert ${className} alert-dismissible fade show`} role="alert">
                <strong>{ title }</strong> { text }
                <button type="button" className="close" data-dismiss="alert" aria-label="Close" onClick={onCloseAlertHandler}>
                    <span aria-hidden="true">×</span>
                </button>
            </div>)
        : (<></>);

    return alert;
};

export default Alert;
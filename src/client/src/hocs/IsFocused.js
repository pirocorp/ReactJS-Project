const IsFocused = (Component) => {
    const isFocused = (state) => state ? 'focused' : '';

    const onInputBlurHandler = (e, setState) => setState((oldState) => ({ ...oldState, [e.target.name]: e.target.value }));

    return(props) => (
        <Component {...props} isFocused={ isFocused } onInputBlurHandler={ onInputBlurHandler } />
    );
};

export default IsFocused;
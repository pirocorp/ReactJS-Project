import authService from "../../services/authService";

const TestComponent = (props) => {

    console.log(authService.getRole(props.user?.token));

    return(
        <h1>This will be protected test component.</h1>
    );
}

export default TestComponent;
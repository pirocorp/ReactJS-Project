import authService from "../../services/authService";

const TestComponent = (props) => {

    const role = authService.getRole(props.user?.token);
    let element = <></>;

    switch (role) {
        case "Patient":
            element = <h1>Patient</h1>
            break;
        case "Doctor":
            element = <h1>Doctor</h1>
            break;
        case "Administrator":
            element = <h1>Admin</h1>
            break;
        default:
            element = <h1>Anonymous</h1>
    }

    return element;
}

export default TestComponent;
import { useContext } from 'react';

import authService from "../../services/authService";

import UserContext from '../../contexts/UserContext';

const TestComponent = () => {

    const { user } = useContext(UserContext);

    const role = authService.getRole(user?.token);
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

    console.log(role.asd()); // Test Error Boundary Component

    return element;
}

export default TestComponent;
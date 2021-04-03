import { useState } from 'react';

import authService from '../services/authService';

export default function useUser() {
    const [user, setUser] = useState(authService.getCurrentUser());

    const saveUser = (user) => {
        authService.setCurrentUser(user);
        setUser(user);
    }

    return [
        user,
        saveUser
    ]
}
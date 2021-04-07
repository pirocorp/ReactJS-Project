import React from 'react';

const UserContext = React.createContext({
    user: {},
    profileId: '',
    setUser: () => {},
});

UserContext.displayName = 'User Context';
export default UserContext;
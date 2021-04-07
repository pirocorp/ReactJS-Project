import React from 'react';

const UserContext = React.createContext({
    user: {},
    setUser: () => {},
});

UserContext.displayName = 'User Context';
export default UserContext;
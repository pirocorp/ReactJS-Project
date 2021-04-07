import React from 'react';

const MobileMenuContext = React.createContext({
    openMenu: false, 
    setOpenMenu: () => {},
});

MobileMenuContext.displayName = 'Mobile Menu Context';
export default MobileMenuContext;
import MenuHeader from './MenuHeader';
import MenuNavigation from './MenuNavigation';

import './MainMenu.css';

const MainMenu = ({
    setOpenMenu
}) => {
    return(
        <div className="main-menu-wrapper">
            <MenuHeader setOpenMenu={ setOpenMenu } />
            <MenuNavigation />
        </div>
    );
}

export default MainMenu;
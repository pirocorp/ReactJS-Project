import MenuHeader from './MenuHeader';
import MenuNavigation from './MenuNavigation';

import './MainMenu.css';

const MainMenu = () => {
    return(
        <div className="main-menu-wrapper">
            <MenuHeader />
            <MenuNavigation />
        </div>
    );
}

export default MainMenu;
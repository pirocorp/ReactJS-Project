import HomeBanner from './HomeBanner';

import Specialities from './Specialities/';
import PopularSection from './PopularSection/';

import './Home.css';

function Home() {
    return(
        <>
            <HomeBanner />
            <Specialities />
            <PopularSection />
        </>
    );
}

export default Home;
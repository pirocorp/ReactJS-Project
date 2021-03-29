import HomeBanner from './HomeBanner';

import Specialities from './Specialities/';
import PopularSection from './PopularSection/';

import './Home.css';
import Features from './Features/Features';

function Home() {
    return(
        <>
            <HomeBanner />
            <Specialities />
            <PopularSection />
            <Features />
        </>
    );
}

export default Home;
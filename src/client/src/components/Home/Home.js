import HomeBanner from './HomeBanner';

import Specialities from './Specialities/';
import PopularSection from './PopularSection/';

import './Home.css';
import Features from './Features/Features';

function Home(props) {
    return(
        <>
            <HomeBanner {... props}/>
            <Specialities />
            <PopularSection />
            <Features />
        </>
    );
}

export default Home;
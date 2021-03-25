import Search from './Search';

import './HomeBanner.css';

function HomeBanner() {
    return (
        <section className="section section-search">
            <div className="container-fluid">
                <div className="banner-wrapper">
                    <div className="banner-header text-center">
                        <h1>Search Doctor, Make an Appointment</h1>
                        <p>Discover the best doctors, in this clinic.</p>
                    </div>

                    <Search />
                </div>
            </div>
        </section>
    );
}

export default HomeBanner;
import CopyrightMenu from './CopyrightMenu';

import './Copyright.css';

const Copyright = () => {
    return(
        <div className="copyright">
            <div className="row">
                <div className="col-md-6 col-lg-6">
                    <div className="copyright-text">
                        <p className="mb-0"><a href="https://github.com/pirocorp/ReactJS-Project">GitHub</a></p>
                    </div>
                </div>
                <div className="col-md-6 col-lg-6">

                    <CopyrightMenu />

                </div>
            </div>
        </div>
    );
}

export default Copyright;
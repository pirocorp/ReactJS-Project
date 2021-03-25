import CopyrightMenu from './CopyrightMenu';

import './Copyright.css';

const Copyright = () => {
    return(
        <div className="copyright">
            <div className="row">
                <div className="col-md-6 col-lg-6">
                    <div className="copyright-text">
                        <p className="mb-0"><a target="_blank" href="https://github.com/pirocorp/ReactJS-Project" rel="noreferrer">GitHub</a></p>
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
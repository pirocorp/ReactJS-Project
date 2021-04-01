import { Link } from 'react-router-dom';

import './Breadcrumb.css';

function Breadcrumb({
    active,
    title
}) {
    return (
        <div className="breadcrumb-bar">
            <div className="container-fluid">
                <div className="row align-items-center">
                    <div className="col-md-8 col-12">
                        <nav aria-label="breadcrumb" className="page-breadcrumb">
                            <ol className="breadcrumb">
                                <li className="breadcrumb-item"><Link to="/">Home</Link></li>
                                <li className="breadcrumb-item active" aria-current="page">{active}</li>
                            </ol>
                        </nav>
                        <h2 className="breadcrumb-title">{title}</h2>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default Breadcrumb;
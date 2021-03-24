import './FooterWidget.css';

const FooterWidget = (props) => {
    return(
        <div className="col-lg-3 col-md-6">
            {props.children}
        </div>
    );
}

export default FooterWidget;
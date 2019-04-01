import React from 'react';

const Header = (props) => (
    <header className = "raw">
    <div className="row-md-5"></div>
        <div className="col-md-12 mt-5 ml-1 main-title">
            {props.subtitle}
        </div>
        <div className="col-md-5"></div>
        
    </header>
 );

export default Header;
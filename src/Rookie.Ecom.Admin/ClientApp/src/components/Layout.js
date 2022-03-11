import React from 'react';
import { Container } from 'reactstrap';
import NavMenu from './NavMenu/NavMenu';
import SideBar from './NavMenu/SideBar';

export default props => (
    <div>
        <NavMenu />
        <div class="row">
            <div class="col-md-1"/>
            <div class="col-md-2">
                <SideBar />
            </div>
            <div class="col-md-8">
                <Container>
                    {props.children}
                </Container>
            </div>
            <div class="col-md-1"/>
        </div>
        {/*        <SideBar />
        <Container>
            {props.children}
        </Container>*/}
    </div>
);

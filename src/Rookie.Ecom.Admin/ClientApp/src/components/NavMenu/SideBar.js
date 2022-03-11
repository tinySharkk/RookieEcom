import React from 'react';
import {
    Collapse,
    Container,
    Navbar,
    NavbarBrand,
    NavbarToggler,
    NavItem,
    NavLink,
    Nav
} from 'reactstrap';
import { Link } from 'react-router-dom';
import './SideBar.css';
import classNames from "classnames";
/*import SubMenu from "./SubMenu.js";*/

import { connect } from 'react-redux';

class SideBar extends React.Component {
    constructor(props) {
        super(props);

        this.toggle = this.toggle.bind(this);
        this.state = {
            isOpen: false
        };
    }
    toggle() {
        this.setState({
            isOpen: !this.state.isOpen
        });
    }
    render() {
        const { isOpen, toggle } = this.props
        return (
            <div className={classNames("sidebar", { "is-open": isOpen })}>
                <div className="sidebar-header">
                    <span color="info" onClick={toggle} style={{ color: "#fff" }}>
                        &times;
                    </span>
                    <h3>Bootstrap Sidebar</h3>
                </div>
                <div className="side-menu">
                    <Nav vertical className="list-unstyled pb-3">
                        {/*<SubMenu title="Home" items={submenus[0]} />*/}
                        <NavItem>
                            <NavLink tag={Link} to={"/"}>
                                Home
                            </NavLink>
                        </NavItem>
                        {/*<SubMenu title="Pages" items={submenus[1]} />*/}
                        <NavItem>
                            <NavLink tag={Link} to="/category">
                                Category
                            </NavLink>
                        </NavItem>
                        <NavItem>
                            <NavLink tag={Link} to="/product">
                                Product
                            </NavLink>
                        </NavItem>
                        <NavItem>
                            <NavLink tag={Link} to="/counter">
                                Counter
                            </NavLink>
                        </NavItem>
                        <NavItem>
                            <NavLink tag={Link} to="/fetch-data">
                                Fetch data
                            </NavLink>
                        </NavItem>
                    </Nav>
                </div>
            </div>
        );
    }
}

function mapStateToProps(state) {
    return {
        user: state.oidc.user,
        isAuthenticated: state.oidc.user && !state.oidc.user.expired
    };
}

function mapDispatchToProps(dispatch) {
    return {
        dispatch
    };
}

const submenus = [
    [
        {
            title: "Home 1",
            target: "Home-1",
        },
        {
            title: "Home 2",
            target: "Home-2",
        },
        {
            itle: "Home 3",
            target: "Home-3",
        },
    ],
    [
        {
            title: "Page 1",
            target: "Page-1",
        },
        {
            title: "Page 2",
            target: "Page-2",
        },
    ],
];


export default connect(
    mapStateToProps,
    mapDispatchToProps
)(SideBar);

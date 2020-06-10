import React, { Component } from "react";
import {
  Collapse,
  Container,
  Navbar,
  NavbarBrand,
  NavbarToggler,
  NavItem,
  NavLink,
} from "reactstrap";
import { Link } from "react-router-dom";
import "./NavMenu.css";
import moment from "moment";

export class NavMenu extends Component {
  static displayName = NavMenu.name;
  constructor(props) {
    super(props);
    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true,
      lastUpdateDate: "2020-06-02 12:30",
    };
  }

  componentWillReceiveProps(nextProps) {
    console.log("刷新最后更新时间");
    this.getLastUpdateInfo();
  }

  componentWillUnmount(){
    this.setState = (state,callback)=>{
       return;
     };
  }

  componentDidMount() {
    this.getLastUpdateInfo();
  }

  toggleNavbar() {
    this.setState({
      collapsed: !this.state.collapsed,
    });
  }

  render() {
    const tipStyle = {
      color: "#b1aeae",
      fontSize: 12,
      marginTop: 3,
      marginLeft: 8,
    };

    return (
      <header>
        <Navbar
          className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3"
          light
        >
          <Container>
            <NavbarBrand tag={Link} to="/devops">
              下城需求体系管理系统
            </NavbarBrand>
            <div style={tipStyle}>
              最后更新时间: {this.state.lastUpdateDate}
            </div>
            <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
            <Collapse
              className="d-sm-inline-flex flex-sm-row-reverse"
              isOpen={!this.state.collapsed}
              navbar
            >
              <ul className="navbar-nav flex-grow">
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/devops">
                    项目报表
                  </NavLink>
                </NavItem>
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/daily-report">
                    日报管理
                  </NavLink>
                </NavItem>
                {/* <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/home">
                    Home
                  </NavLink>
                </NavItem> */}
              </ul>
            </Collapse>
          </Container>
        </Navbar>
      </header>
    );
  }

  // api
  async getLastUpdateInfo() {
    const response = await fetch(`Project/GetLastUpdateInfo`);
    const data = await response.json();
    this.setState({
      lastUpdateDate: moment(data.lastUpdateDate).format("YYYY-MM-DD HH:mm"),
    });
  }
}

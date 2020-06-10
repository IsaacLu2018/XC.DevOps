import React, { Component } from "react";
import { Container } from "reactstrap";
import { NavMenu } from "./NavMenu";
import { Layout,ConfigProvider } from "antd";
import Logo from "../Icons/Logo.png";
import zhCN from "antd/es/locale/zh_CN";
const { Footer } = Layout;

export class DevLayout extends Component {
  static displayName = Layout.name;
  state = { hover: false, isUpdate: false };

  componentWillReceiveProps(nextProps) {
    const state = this.state.isUpdate ? false : true;
    this.setState({ isUpdate: state });
  }
  componentWillUnmount() {
    this.setState = (state, callback) => {
      return;
    };
  }

  render() {
    let linkStyle = this.state.hover
      ? { color: "#40a9ff" }
      : { color: "rgba(0, 0, 0, 0.65)" };
    return (
      <div>
        <NavMenu isUpdate={this.state.isUpdate} />
        <Container style={{ minHeight: 600 }}><ConfigProvider locale={zhCN}>{this.props.children}</ConfigProvider></Container>
        <Footer style={{ textAlign: "center", backgroundColor: "white" }}>
          <img
            src={Logo}
            style={{ height: 62, marginBottom: 40, marginTop: 30 }}
          ></img>
          <p>Copyright ©2020 下城区数据资源管理局</p>
          <p>
            需求体系管理系统 V1.0 Develop by
            <a
              href="https://ssw.com.cn"
              target="_blank"
              style={linkStyle}
              onMouseEnter={() => this.setState({ hover: true })}
              onMouseLeave={() => this.setState({ hover: false })}
            >
              {" "}
              智鹏瑞尔软件
            </a>
          </p>
        </Footer>
      </div>
    );
  }
}

import {
  Descriptions,
  Divider,
  Card,
  Spin,
  DatePicker,
  Row,
  Col,
  ConfigProvider,
  Select,
} from "antd";
import { employers } from "../mock/users";
import React from "react";
import moment from "moment";
import { find } from "lodash";
import zhCN from "antd/es/locale/zh_CN";
import { infoData } from "../mock/reports";
import "moment/locale/zh-cn";

moment.locale("zh-cn");
const _ = require("underscore");
const { Option } = Select;

export class DailyReport extends React.Component {
  state = {
    data: [],
    loading: true,
    current: "employer",
    day: moment(new Date()).format("YYYY-MM-DD"),
    employers: [],
    projects: [],
    currentEmp: undefined,
    currentProject: undefined,
    allData: [],
  };

  FormatJson = (json) => {
    let infoJson = [];
    const devJson = _.groupBy(json, "assignTo");
    // 取出用户
    let users = [];

    Object.keys(devJson).forEach((m) => {
      if (m && m !== "null") {
        users.push(m);
      }
    });
    users.forEach((u) => {
      const projectGroup = _.groupBy(devJson[u], "projectNodeName");
      let projectNameList = [];
      let projectList = [];
      Object.keys(projectGroup).map((m) => projectNameList.push(m));
      projectNameList.forEach((p) => {
        let Items = projectGroup[p];
        let project = { projectName: "", projectGUID: "", Items: [] };
        project.Items = Items;
        // 处理一段特殊列 渲染在第一列
        const workItem = {
          workItemType: "项目",
          workItemTitle: p,
          id: p,
        };
        project.Items.unshift(workItem);

        project.projectName = p;
        project.projectGUID = Items.length >= 1 ? Items[1].projectNodeGUID : "";

        projectList.push(project);
      });
      let sum = 0;
      projectList.forEach((p) => {
        p.Items.forEach((m) => {
          if (m.manHour) {
            sum += m.manHour;
          }
        });
      });
      console.log("sum", sum);
      infoJson.push({ assignTo: u, projectList, sum });
    });
    console.log("infoJson", infoJson);
    return infoJson;
  };

  // 改变任意状态重新筛选内容
  FilterData = () => {
    const { currentEmp, currentProject, allData } = this.state;
    let newData = allData;
    let newProject = [];
    // 当前没有选择任何项目
    // TODO：排序为更新 需要调用api....
    if(!currentEmp&!currentProject){
      newProject = allData;
    }
    else
    {
      // 当前成员有值
      if (currentEmp) {
        allData.forEach((d) =>{
          if(d.assignTo === currentEmp){
            newProject.push(d);
          }
        });
        newData = newProject;
      }
      // 当前项目有值
      if (currentProject) {
        newProject = [];
        newData.forEach((d) => {
          const userInfo = {
            assignTo: d.assignTo,
            projectList: [],
            sum: 0,
          };

          if (d.projectList.length > 0) {
            d.projectList.forEach((p) => {
              console.log('p', p);
              if (p.projectName === currentProject) {
                userInfo.projectList.push(p);
                userInfo.sum = p.Items.length - 1;
                newProject.push(userInfo);
              }
            });
          } 
        });
      }
    }
   
    this.setState({ data: newProject });
  };

  //优化后格式化方法
  handleTransform = () => {
    let newData = [];
    console.log("infoData", infoData);
    infoData.forEach(
      ({ assignTo, projectNodeGUID, projectNodeName, ...restItem }) => {
        const firstItem = find(newData, { assignTo });
        if (firstItem) {
          // 列表里已经存在第一层数据,开始查询第二层
          const secondItem = find(firstItem.projectList, { projectNodeGUID });
          if (secondItem) {
            // 列表已经存在第二层数据,直接存储
            secondItem.items.push(restItem);
          } else {
            // 列表不存在第二层数据
            firstItem.projectList.push({
              projectNodeName,
              projectNodeGUID,
              items: [restItem],
            });
          }
        } else {
          // 列表不存在第一层数据
          newData.push({
            assignTo,
            projectList: [
              {
                projectNodeName,
                projectNodeGUID,
                items: [restItem],
              },
            ],
          });
        }
      }
    );
    console.log("FFnewData", newData);
  };

  onChange = (date, dateString) => {
    if (date) {
      this.setState({ day: dateString });
      // 重新加载
      this.GetWorkItems(dateString);
    } else {
      this.setState({ day: null });
    }
  };

  handleClick = (e) => {
    this.setState({
      current: e.key,
    });
  };

  componentDidMount() {
    this.GetWorkItems(this.state.day);
    this.GetProjects();
  }

  render() {
    const { data, loading, projects } = this.state;
    const dateFormat = "YYYY-MM-DD";

    const InfoItem = (key, value) => (
      <div key={`${key}`}>
        <p>{value}</p>
        <Divider />
      </div>
    );

    const InfoCard = (data) => (
      <Card
        title={data.assignTo}
        // extra={<a href="#">More</a>}
        style={{ marginTop: 5 }}
        key={`Card-${data.assignTo}`}
      >
        <Descriptions layout="vertical" bordered>
          <Descriptions.Item label="类型">
            {data.projectList.map((m) =>
              m.Items.map((e) =>
                InfoItem(`workItemType-${e.system_Id}`, e.workItemType)
              )
            )}
          </Descriptions.Item>
          <Descriptions.Item label="工作任务">
            {data.projectList.map((m) =>
              m.Items.map((e) =>
                InfoItem(`workItemTitle-${e.system_Id}`, e.workItemTitle)
              )
            )}
          </Descriptions.Item>
          <Descriptions.Item label="工时（小时）">
            {data.projectList.map((m) =>
              m.Items.map((e) =>
                InfoItem(`manHour-${e.system_Id}`, e.manHour ? e.manHour : "\\")
              )
            )}
          </Descriptions.Item>
          <Descriptions.Item label="合计" span={2}></Descriptions.Item>
          <Descriptions.Item label={data.sum}></Descriptions.Item>
        </Descriptions>
      </Card>
    );

    const ReprotMenu = () => (
      <Row>
        <Col span={4}>
          <DatePicker
            value={
              this.state.day ? moment(this.state.day, dateFormat) : undefined
            }
            format={dateFormat}
            onChange={this.onChange}
            style={{ marginTop: 15 }}
          />
        </Col>
        <Col style={{ marginLeft: -37 }}>
          {/* <Menu
          onClick={this.handleClick}
          mode="horizontal"
          selectedKeys={[this.state.current]}
        >
          <Menu.Item key="employer" icon={<TeamOutlined />}>
            人员
          </Menu.Item>
          <Menu.Item key="project" icon={<LaptopOutlined />}>
            项目
          </Menu.Item>
        </Menu> */}
          {Selecter("人员", employers)}
          {Selecter("项目", projects)}
        </Col>
      </Row>
    );

    const Selecter = (type, data) => {
      const { currentEmp, currentProject } = this.state;
      const onChange = (value) => {
        // 设置选中的内容
        if (type === "人员") {
          this.setState(
            {
              currentEmp:value
            }, ()=> {
               this.FilterData();
            }
          );
        } else if (type === "项目") {
          this.setState(
            {
              currentProject:value
            }, ()=> {
               this.FilterData();
            }
          );
        }
        console.log(`${type} selected ${value}`);
      };

      function onBlur() {
        console.log("blur");
      }

      function onFocus() {
        console.log("focus");
      }

      function onSearch(val) {
        console.log("search:", val);
      }

      return (
        <Select
          showSearch
          style={{ width: 160, marginTop: 15, marginLeft: 10 }}
          placeholder={`选择${type}`}
          optionFilterProp="children"
          onChange={onChange}
          value={type === "人员" ? currentEmp : currentProject}
          onFocus={onFocus}
          onBlur={onBlur}
          onSearch={onSearch}
          filterOption={(input, option) =>
            option.children.toLowerCase().indexOf(input.toLowerCase()) >= 0
          }
          allowClear
        >
          {data.map((m, index) => (
            <Option value={m} key={`${type}_option_${index}`}>
              {m}
            </Option>
          ))}
        </Select>
      );
    };

    return (
      <ConfigProvider locale={zhCN}>
        <ReprotMenu />
        <Divider orientation="left">日报详情</Divider>
        <Spin tip="加载中..." spinning={loading}>
          {data.map((j) => InfoCard(j))}
        </Spin>
      </ConfigProvider>
    );
  }

  // 初始化人员列表
  async GetWorkItems(day) {
    const response = await fetch(`Project/GetWorkItems?day=${day}`);
    const resJson = await response.json();
    const data = this.FormatJson(resJson);
    console.log("data", data);
    this.setState({
      loading: false,
      data,
      allData: data,
    });
  }

  // 获取项目列表
  async GetProjects() {
    const response = await fetch(`Project/GetProjects`);
    const data = await response.json();
    console.log("getProjects", data);
    this.setState({
      projects: data,
    });
  }
}

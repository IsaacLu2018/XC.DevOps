import {
  Descriptions,
  Divider,
  Card,
  Spin,
  DatePicker,
  Menu,
  Row,
  Col,
} from "antd";
import { TeamOutlined, LaptopOutlined } from "@ant-design/icons";
import React from "react";
import moment from "moment";
import { find } from "lodash";
const _ = require("underscore");
const infoData = [
  {
    parentSK: 0,
    workItemTreeSK: 20,
    system_Id: 3,
    workItemTitle: "1do 任务同步（discussion && 状态）",
    assignTo: null,
    workItemType: "问题",
    projectNodeGUID: "f1cd5df8-2ca9-4cb7-8bac-a29abac964ea",
    projectNodeName: "DevOps实施",
    closedTime: "2020-05-27T18:13:41.973",
    manHour: null,
  },
  {
    parentSK: 0,
    workItemTreeSK: 23,
    system_Id: 5,
    workItemTitle: "项目进度报表开发协助",
    assignTo: null,
    workItemType: "问题",
    projectNodeGUID: "f1cd5df8-2ca9-4cb7-8bac-a29abac964ea",
    projectNodeName: "DevOps实施",
    closedTime: null,
    manHour: null,
  },
  {
    parentSK: 0,
    workItemTreeSK: 37,
    system_Id: 8,
    workItemTitle: "日报获取、展示",
    assignTo: null,
    workItemType: "问题",
    projectNodeGUID: "f1cd5df8-2ca9-4cb7-8bac-a29abac964ea",
    projectNodeName: "DevOps实施",
    closedTime: "2020-05-29T14:58:41.76",
    manHour: null,
  },
  {
    parentSK: 0,
    workItemTreeSK: 43,
    system_Id: 9,
    workItemTitle: "Azure Devops生产环境logo换掉",
    assignTo: null,
    workItemType: "问题",
    projectNodeGUID: "f1cd5df8-2ca9-4cb7-8bac-a29abac964ea",
    projectNodeName: "DevOps实施",
    closedTime: "2020-05-28T15:52:17.413",
    manHour: null,
  },
  {
    parentSK: 0,
    workItemTreeSK: 46,
    system_Id: 1,
    workItemTitle: "第三方账户集成域账户登录",
    assignTo: null,
    workItemType: "问题",
    projectNodeGUID: "f1cd5df8-2ca9-4cb7-8bac-a29abac964ea",
    projectNodeName: "DevOps实施",
    closedTime: null,
    manHour: null,
  },
  {
    parentSK: 0,
    workItemTreeSK: 49,
    system_Id: 31,
    workItemTitle: "需求01",
    assignTo: null,
    workItemType: "用户情景",
    projectNodeGUID: "1b455782-0a51-40c7-91fc-7e9ece525534",
    projectNodeName: "DevOps系统测试",
    closedTime: null,
    manHour: null,
  },
  {
    parentSK: 0,
    workItemTreeSK: 50,
    system_Id: 32,
    workItemTitle: "需求02",
    assignTo: null,
    workItemType: "用户情景",
    projectNodeGUID: "1b455782-0a51-40c7-91fc-7e9ece525534",
    projectNodeName: "DevOps系统测试",
    closedTime: null,
    manHour: null,
  },
  {
    parentSK: 20,
    workItemTreeSK: 47,
    system_Id: 29,
    workItemTitle: "模版配置",
    assignTo: "周文洋",
    workItemType: "任务",
    projectNodeGUID: "f1cd5df8-2ca9-4cb7-8bac-a29abac964ea",
    projectNodeName: "DevOps实施",
    closedTime: "2020-05-29T15:01:43.29",
    manHour: null,
  },
  {
    parentSK: 23,
    workItemTreeSK: 30,
    system_Id: 24,
    workItemTitle: "提供wiki接口",
    assignTo: null,
    workItemType: "任务",
    projectNodeGUID: "f1cd5df8-2ca9-4cb7-8bac-a29abac964ea",
    projectNodeName: "DevOps实施",
    closedTime: "2020-05-29T15:00:14.43",
    manHour: null,
  },
  {
    parentSK: 37,
    workItemTreeSK: 38,
    system_Id: 25,
    workItemTitle: "原型设计",
    assignTo: "周文洋",
    workItemType: "任务",
    projectNodeGUID: "f1cd5df8-2ca9-4cb7-8bac-a29abac964ea",
    projectNodeName: "DevOps实施",
    closedTime: "2020-05-29T09:20:24.183",
    manHour: null,
  },
  {
    parentSK: 37,
    workItemTreeSK: 40,
    system_Id: 26,
    workItemTitle: "接口开发",
    assignTo: "陈晓平",
    workItemType: "任务",
    projectNodeGUID: "f1cd5df8-2ca9-4cb7-8bac-a29abac964ea",
    projectNodeName: "DevOps实施",
    closedTime: "2020-05-29T09:25:13.773",
    manHour: null,
  },
  {
    parentSK: 43,
    workItemTreeSK: 44,
    system_Id: 27,
    workItemTitle: "替换文本",
    assignTo: "陈晓平",
    workItemType: "任务",
    projectNodeGUID: "f1cd5df8-2ca9-4cb7-8bac-a29abac964ea",
    projectNodeName: "DevOps实施",
    closedTime: "2020-05-29T15:01:03.32",
    manHour: null,
  },
  {
    parentSK: 46,
    workItemTreeSK: 48,
    system_Id: 30,
    workItemTitle: "验证",
    assignTo: "周文洋",
    workItemType: "任务",
    projectNodeGUID: "f1cd5df8-2ca9-4cb7-8bac-a29abac964ea",
    projectNodeName: "DevOps实施",
    closedTime: "2020-05-29T15:02:01.57",
    manHour: null,
  },
  {
    parentSK: 49,
    workItemTreeSK: 51,
    system_Id: 33,
    workItemTitle: "任务01",
    assignTo: "周文洋",
    workItemType: "任务",
    projectNodeGUID: "1b455782-0a51-40c7-91fc-7e9ece525534",
    projectNodeName: "DevOps系统测试",
    closedTime: "2020-05-29T15:17:48.537",
    manHour: 4,
  },
  {
    parentSK: 50,
    workItemTreeSK: 52,
    system_Id: 34,
    workItemTitle: "任务02",
    assignTo: "周文洋",
    workItemType: "任务",
    projectNodeGUID: "1b455782-0a51-40c7-91fc-7e9ece525534",
    projectNodeName: "DevOps系统测试",
    closedTime: "2020-05-29T15:19:47.6",
    manHour: 5,
  },
];

export class DailyReport extends React.Component {
  state = {
    data: [],
    loading: true,
    current: "employer",
    day: moment(new Date()).format("YYYY-MM-DD"),
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
    console.log(date, dateString);
    this.setState({ day: dateString });
    // 重新加载
    this.GetWorkItems(dateString);
  };

  handleClick = (e) => {
    console.log("click ", e);
    this.setState({
      current: e.key,
    });
  };

  componentDidMount() {
    this.GetWorkItems(this.state.day);
  }

  render() {
    const { data, loading } = this.state;
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
          <Descriptions.Item label="工时">
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
          defaultValue={moment(this.state.day, dateFormat)}
          format={dateFormat}
          onChange={this.onChange}
          style={{marginTop:15}}
        />
        </Col>
        <Col >
        <Menu
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
        </Menu>
        </Col>
        
      </Row>
    );

    return (
      <div>
        <ReprotMenu />
        <Spin spinning={loading}>{data.map((j) => InfoCard(j))}</Spin>
      </div>
    );
  }

  // 初始化人员列表
  async GetWorkItems(day) {
    // const url = `http://59.202.68.89:8080/api/Project/WorkItems?day=${day}`;
    // var req = new Request(url, {
    //   method: "POST",
    //   headers: {
    //     'Access-Control-Allow-Origin':'*',
    //     "Content-Type": "application/json"
    //   },
    //   // mode: "no-cors"
    // });
    // const response = await fetch(req);
    // const data = await response.json();

    const response = await fetch(`Project/GetWorkItems?day=${day}`);
    const resJson = await response.json();
    const data = this.FormatJson(resJson);
    console.log("data", data);
    this.setState({
      loading: false,
      data,
    });
  }
}

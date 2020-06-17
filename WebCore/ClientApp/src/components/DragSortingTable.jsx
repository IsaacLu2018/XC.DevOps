import {
  Form,
  Input,
  Table,
  Modal,
  DatePicker,
  Select,
  Row,
  Col,
  Button,
  Spin,
  message,
  Tooltip,
  Rate,
} from "antd";
import { UserOutlined } from "@ant-design/icons";
import { DndProvider, useDrag, useDrop } from "react-dnd";
import { HTML5Backend } from "react-dnd-html5-backend";
import update from "immutability-helper";
import React from "react";
import { EditorState } from "draft-js";
import draftToMarkdown from "draftjs-to-markdown";
import { MarkDownEditor } from "./MarkDownEditor";
import "react-draft-wysiwyg/dist/react-draft-wysiwyg.css";
import star from "../Icons/star0.png";
import grayStar from "../Icons/star1.png";
import "./DragSortingTable.css";
import moment from "moment";
import "moment/locale/zh-cn";
import { stateList } from "../mock/stateList";

moment.locale("zh-cn");
const type = "DragableBodyRow";
const { Option } = Select;
// 排序基数
const _baseOrder = 655236;
let content = "";
let myStars = 0;
let DragableBodyRow = ({ index, moveRow, className, style, ...restProps }) => {
  const ref = React.useRef();
  const [{ isOver, dropClassName }, drop] = useDrop({
    accept: type,
    collect: (monitor) => {
      const { index: dragIndex } = monitor.getItem() || {};
      if (dragIndex === index) {
        return {};
      }
      return {
        isOver: monitor.isOver(),
        dropClassName:
          dragIndex < index ? " drop-over-downward" : " drop-over-upward",
      };
    },
    drop: (item) => {
      moveRow(item.index, index);
    },
  });
  const [, drag] = useDrag({
    item: { type, index },
    collect: (monitor) => ({
      isDragging: monitor.isDragging(),
    }),
  });
  drop(drag(ref));
  return (
    <tr
      ref={ref}
      className={`${className}${isOver ? dropClassName : ""}`}
      style={{ ...style }} // cursor: "move",
      {...restProps}
    />
  );
};
class DragSortingTable extends React.Component {
  state = {
    loadingAll: true,
    loading: false,
    data: [],
    currentId: "",
    visible: false,
    editorState: EditorState.createEmpty(),
    title: "",
    state: "new",
    team: "",
    manager: "",
    client: "",
    priority: 0,
    startTime: moment(),
    endTime: moment(),
    description: undefined,
    currentTitle: "",
    markdownContent: "",
    disableDrag: false,
  };

  componentDidMount() {
    // 获取全部数据
    this.getAll();
    // 格式化数据
  }

  componentWillUnmount() {}
  components = {
    body: {
      row: DragableBodyRow,
    },
  };

  // 获取某一个Id下的数据
  showModal = (e, record) => {
    e.preventDefault();
    const { id, title } = record;
    // TODO: 先置空表单数据
    this.setState({
      loading: true,
      visible: true,
      currentId: id,
      currentTitle: title,
    });
    this.getItem(id);
  };

  moveRow = (dragIndex, hoverIndex) => {
    const { data } = this.state;
    const dragRow = data[dragIndex];
    const count = data.length;
    if (this.state.disableDrag) {
      message.error("请勿在筛选状态下排序");
    } else {
      // 1. 移动至顶端
      // 2. 中间移动
      // 3. 移动至于底部
      // 没动就不处理逻辑了
      let priority = dragRow.priority;
      let order = 2.0;

      //没有发生移动 就不更新了
      if (hoverIndex !== dragIndex) {
        // 移动至最顶端
        if (hoverIndex === 0) {
          // TODO: 有问题 如果第一个为0... （排除0的可能？）
          // TODO: order = data[0].order -_baseOrder
          order = data[0].order - _baseOrder;
        }
        // 移动至最底部
        else if (hoverIndex + 1 === count) {
          order = data[hoverIndex].order + _baseOrder;
        }
        // 中间的移动
        else {
          // 默认为向上移动
          let topRow = data[hoverIndex - 1];
          let nextRow = data[hoverIndex];
          // 向下移动
          if (hoverIndex > dragIndex) {
            topRow = data[hoverIndex];
            nextRow = data[hoverIndex + 1];
          }
          order = (topRow.order + nextRow.order) / 2;
        }
        const Id = dragRow.id;
        // 设置
        this.setOrder(Id, priority, order);
      }

      this.setState(
        update(this.state, {
          data: {
            $splice: [
              [dragIndex, 1],
              [hoverIndex, 0, dragRow],
            ],
          },
        })
      );
    }
  };

  //获取内容变化值
  onEditorChange = (editorContent) => {
    const markDownContent = editorContent && draftToMarkdown(editorContent);
    // 过滤\s
    const filterS = markDownContent.replace(/\\s/g, "");
    // content = filterS;
  };

  onChangeMarkDown = (markdownContent) => {
    const filterS = markdownContent.replace(/\\s/g, "");
    content = filterS;
    console.log("In onChangeMarkDown", markdownContent);
    // this.setState({ markdownContent });
  };

  render() {
    const columns = [
      {
        title: "序号",
        dataIndex: "id",
        key: "id",
        width: 50,
        render: (text, record, index) => `${index + 1}`,
      },
      {
        title: "项目名称",
        dataIndex: "title",
        key: "title",
        ellipsis: {
          showTitle: false,
        },
        width: 300,
        render: (text, record) => (
          <Tooltip
            placement="topLeft"
            title={text}
            onClick={(e) => this.showModal(e, record)}
          >
            <a href="">{text}</a>
          </Tooltip>
        ),
      },
      {
        title: "状态",
        dataIndex: "state",
        key: "state",
        ellipsis: true,
        filters: stateList,
        onFilter: (value, record) => {
          if (record.state) {
            return record.state.indexOf(value) === 0;
          }else{
            return false;
          }
        },
        render: (text, record) => `${record.stateValue}`,
      },
      {
        title: "星级",
        dataIndex: "priority",
        key: "priority",
        align: "center",
        // width: 120,
        render: (text) => {
          const count = Number(text);
          const grayCount = 10 - count;
          var stars = [];
          for (let index = 0; index < 10; index++) {
            if (index < count) {
              stars.push(
                <img key={`star-${index}`} style={{ height: 8 }} src={star} />
              );
            } else {
              stars.push(
                <img
                  key={`gray-star-${index}`}
                  style={{ height: 8 }}
                  src={grayStar}
                />
              );
            }
          }
          return stars;
        },
      },
      {
        title: "负责人",
        dataIndex: "manager",
        key: "manager",
        ellipsis: true,
      },
      {
        title: "开发团队",
        dataIndex: "team",
        key: "team",
        ellipsis: true,
      },
      {
        title: "需求方",
        dataIndex: "client",
        key: "client",
        ellipsis: true,
      },
      {
        title: "项目进度",
        dataIndex: "progress",
        key: "progress",
        align: "center",
      },
      {
        title: "查看项目",
        dataIndex: "link",
        key: "link",
        align: "center",
        ellipsis: true,
        render: (text, record) => (
          <a href={text} target="_blank">
            查看
          </a>
        ),
      },
    ];

    const {
      title,
      visible,
      loading,
      state,
      team,
      manager,
      client,
      priority,
      startTime,
      endTime,
      currentId,
      currentTitle,
      loadingAll,
      description,
    } = this.state;

    // 维护一个状态列表
    const StateDropdown = (state) => {
      return (
        <Select value={state} style={{ width: 200 }}>
          {stateList.map((s) => (
            <Option key={`select-${s.value}`} value={s.value}>
              {s.text}
            </Option>
          ))}
        </Select>
      );
    };

    const EditModal = () => {
      const onFinish = (values) => {
        // TODO: 调用api 完成修改
        // TODO: ts 控制类型ProjectModel
        values.startTime = moment(values.startTime).add(1,'day');
        values.endTime = moment(values.endTime).add(1,'day');
        
        values.Id = currentId;
        values.title = currentTitle;
        // 这里直接赋值 传递内容
        values.priority = myStars;
        values.description = content;
        this.setState({
          loading: true,
          loadingAll: true,
          ...values,
        });
        this.update(values);
      };

      const onFinishFailed = (errorInfo) => {
        console.log("Failed:", errorInfo);
      };

      const dateFormat = "YYYY-MM-DD";

      const cancelSubmit = () => {
        this.setState({
          visible: false,
        });
      };

      return (
        <Form
          name="submitForm"
          initialValues={{
            state,
            team,
            manager,
            client,
            priority,
            startTime,
            endTime,
          }}
          onFinish={onFinish}
          onFinishFailed={onFinishFailed}
        >
          <Row>
            <Col span={12}>
              <Form.Item label="项目名称">
                <Input
                  size="middle"
                  value={title}
                  prefix={<UserOutlined className="site-form-item-icon" />}
                />
              </Form.Item>
            </Col>
            <Col span={4}></Col>
            <Col span={8}>
              <Form.Item label="项目状态" name="state">
                {StateDropdown(state)}
              </Form.Item>
            </Col>
          </Row>
          <Row>
            <Col span={16}>
              <Form.Item label="项目描述" name="description">
                <MarkDownEditor
                  onEditorChange={this.onEditorChange}
                  onChangeMarkDown={this.onChangeMarkDown}
                  description={description}
                />
              </Form.Item>
            </Col>
            <Col span={8}>
              <Form.Item>
                <label style={{ width: 300 }}>负责团队</label>
                <Form.Item name="team" style={{ marginBottom: 10 }}>
                  <Input />
                </Form.Item>
                <label style={{ width: 300 }}>项目负责人</label>
                <Form.Item name="manager" style={{ marginBottom: 10 }}>
                  <Input />
                </Form.Item>
                <label style={{ width: 300 }}>需求方（客户）</label>
                <Form.Item name="client" style={{ marginBottom: 10 }}>
                  <Input />
                </Form.Item>
                <label style={{ width: 300 }}>星级</label>
                <Form.Item name="priority" style={{ marginBottom: 10 }}>
                  <Rate
                    count={10}
                    onChange={(priority) => (myStars = priority)}
                  />
                </Form.Item>
                <label style={{ width: 300 }}>开始时间</label>
                <Form.Item name="startTime" style={{ marginBottom: 10 }}>
                  <DatePicker format={dateFormat} />
                </Form.Item>
                <label style={{ width: 300 }}>结束时间</label>
                <Form.Item name="endTime" style={{ marginBottom: 10 }}>
                  <DatePicker format={dateFormat} />
                </Form.Item>
              </Form.Item>
              <Form.Item style={{ marginTop: 20 }}>
                <Row>
                  <Col span={13}></Col>
                  <Col span={6}>
                    <Button onClick={cancelSubmit}>取消</Button>
                  </Col>
                  <Col span={5}>
                    <Button type="primary" htmlType="submit">
                      保存
                    </Button>
                  </Col>
                </Row>
              </Form.Item>
            </Col>
          </Row>
        </Form>
      );
    };

    // 这个方法是为了报这个点击外边框 或者叉可以退出
    const handleCancel = (e) => {
      this.setState({
        visible: false,
      });
    };
    // const RNDContext = createDndContext(HTML5Backend);
    // const manager = useRef(RNDContext);
    return (
      <DndProvider backend={HTML5Backend}>
        <Spin tip="加载中..." spinning={loadingAll}>
          <Table
            size="small"
            columns={columns}
            dataSource={this.state.data}
            components={this.components}
            rowKey={(record) => record.id}
            pagination={false}
            onChange={(pagination, filters) => {
              const disableDrag = filters.state === null ? false : true;
              this.setState({ disableDrag });
            }}
            onRow={(record, index) => ({
              index,
              moveRow: this.moveRow,
              // onMouseEnter: event => {console.log('Enterevent', event)}, // 鼠标移入行
              // onMouseLeave: event => {console.log('Leaveevent', event)},
            })}
          />
        </Spin>
        <Modal
          style
          title="编辑项目"
          visible={visible}
          centered={true}
          width={1000}
          onCancel={handleCancel}
          footer={
            [] // 设置footer为空，去掉 取消 确定默认按钮
          }
        >
          <Spin tip="加载中..." spinning={loading}>
            <EditModal />
          </Spin>
        </Modal>
      </DndProvider>
    );
  }

  // 接口部分

  // 获取全部项目项目
  async getAll() {
    const response = await fetch("Project/GetAll");
    const data = await response.json();
    this.setState({
      data,
      loadingAll: false,
    });
  }

  // 获取单个项目
  async getItem(Id) {
    const response = await fetch(`Project/GetItem?Id=${Id}`);
    const data = await response.json();
    myStars = data.priority;
    this.setState({
      ...data,
      Id: this.state.currentId,
      title: this.state.currentTitle,
      endTime: data.endTime ? moment(data.endTime) : moment(),
      startTime: data.startTime ? moment(data.startTime) : moment(),
      loading: false,
    });
  }

  // 修改某个项目
  async update(model) {
    var req = new Request("Project/Update", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(model),
    });
    const response = await fetch(req);
    const data = await response.json();
    if (data.isSuccess) {
      message.success("更新成功");
    } else {
      message.error(`更新失败，${data.message}`);
    }
    this.setState({
      loading: false,
      visible: false,
    });
    // 重新获取数据
    this.getAll();
  }

  // 更新优先级顺序
  async setOrder(Id, priority, order) {
    var req = new Request(
      `Project/SetOrder?Id=${Id}&priority=${priority}&order=${order}`,
      {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
      }
    );
    const response = await fetch(req);
    await response.json();

    this.setState({ loadingAll: true });
    this.getAll();
    // 触发父组件状态
    this.props.getUpdateState();
  }
}

export default DragSortingTable;

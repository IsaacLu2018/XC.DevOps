import React, { Component } from "react";
import {
  convertFromHTML,
  EditorState,
  ContentState,
} from "draft-js";
import { Editor } from "react-draft-wysiwyg";
import marked from "marked";

marked.setOptions({
  // marked 设置
  renderer: new marked.Renderer(),
  gfm: true,
  tables: true,
  breaks: true,
  pedantic: false,
  sanitize: false,
  smartLists: true,
  smartypants: false,
});

export class MarkDownEditor extends Component {
  constructor(props) {
    super(props);
    const { description } = this.props;
    let markedHTML = "";
    if (description) {
      markedHTML = marked(description);
    }
    this.state = {
      editorState: EditorState.createEmpty(),
      isShowText: false, //是否显示获取得text内容模态框
      defaultEditorState: EditorState.createWithContent(
        ContentState.createFromBlockArray(convertFromHTML(markedHTML))
      ),
    };
  }

  onEditorStateChange = (editorState) => {
    // console.log("editorState", editorState);
    this.setState({
      editorState,
    });
  };

  //获取内容变化值
  onEditorChange = (contentState) => {
    console.log(JSON.stringify(contentState));
    this.props.onEditorChange(contentState);
  };

  handleGetText = () => {
    this.setState({
      isShowText: true,
    });
  };
  render() {
    const {defaultEditorState } = this.state;

    return (
      <div>
        <Editor
          defaultEditorState={defaultEditorState}
          onContentStateChange={this.onEditorChange} //获取内容变化值
          onEditorStateChange={this.onEditorStateChange} //编辑器状态发生变化时
          editorStyle={{
            minHeight: 300,
            width: 600,
            borderStyle: "solid",
            borderWidth: 1,
          }}
        />
      </div>
    );
  }
}

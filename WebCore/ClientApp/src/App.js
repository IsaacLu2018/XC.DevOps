import React, { Component } from "react";
import { Route } from "react-router";
import { DevLayout } from "./components/DevLayout";
import { FetchData } from "./components/FetchData";
import { Counter } from "./components/Counter";
import DragSortingTable from "./components/DragSortingTable";
import { DailyReport } from "./components/DailyReport";
import { Home } from "./components/Home";
import "./custom.css";

export default class App extends Component {
  static displayName = App.name;
  state = { isUpdate: false };

  render() {
    const getUpdateState = () => {
      const state = this.state.isUpdate ? false : true;
      this.setState({ isUpdate: state });
    };

    return (
      <DevLayout isUpdate={this.state.isUpdate}>
        <Route
          exact
          path="/"
          component={() => <DragSortingTable getUpdateState={getUpdateState} />}
        />
        <Route path="/counter" component={Counter} />
        <Route path="/fetch-data" component={FetchData} />
        <Route
          path="/devops"
          component={() => <DragSortingTable getUpdateState={getUpdateState} />}
        />
        <Route path="/daily-report" component={DailyReport} />
        <Route path="/home" component={Home} />
      </DevLayout>
    );
  }
}

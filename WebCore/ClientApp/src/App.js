import React, { Component } from "react";
import { Route } from "react-router";
import { Layout } from "./components/Layout";
import { Home } from "./components/Home";
import { FetchData } from "./components/FetchData";
import { Counter } from "./components/Counter";
import DragSortingTable from "./components/DragSortingTable";
import { DailyReport } from "./components/DailyReport";
import "./custom.css";

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Route exact path="/" component={DragSortingTable} />
        <Route path="/counter" component={Counter} />
        <Route path="/fetch-data" component={FetchData} />
        <Route path="/drag-sorting-table" component={DragSortingTable} />
        <Route path="/daily-report" component={DailyReport} />
      </Layout>
    );
  }
}

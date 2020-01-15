import React from "react";
import TopBar from "./Top/TopBar";
import Body from "./Body/Body";
import Indiv from "./Body/Individual/Indiv";
import { Route, Switch, BrowserRouter as Router } from "react-router-dom";

// Most basic of components for initialisation of the application layer
const Main = () => {
  return (
    <>
      <Router>
      <TopBar />
        <Switch>
          <Route exact path="/">
            <Body />
          </Route>
          <Route path="/indiv">
            <Indiv />
          </Route>
        </Switch>
      </Router>
    </>
  );
};

export default Main;

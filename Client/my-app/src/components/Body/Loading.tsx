import React from "react";
import CircularProgress from "@material-ui/core/CircularProgress";
import "./Style.css";

// Simply  a component to represent loading that's happening
// Center the component onto the screen as appropriate
const Loading = () => {
  return <CircularProgress className="centered" />;
};

export default Loading;
import React from "react";
import { AgGridReact } from "ag-grid-react";
import "ag-grid-community/dist/styles/ag-grid.css";
import "ag-grid-community/dist/styles/ag-theme-balham.css";
import "ag-grid-community/dist/styles/ag-theme-balham-dark.css";
import { Response } from "../Body";
import "../Style.css";

const ready = (params: any) => {
  params.api.sizeColumnsToFit();
};

// Function that makes use of AG Grid to display data
const Table = ({ defs, albums }: Response) => {
  // Method for rendering a table using AG Grid
  return (
    <div
      style={{
        height: "800px",
        width: "1000px",
        marginTop: "20px"
      }}
    >
      <div
        className="ag-theme-balham-dark"
        style={{
          height: "100%",
          width: "100%"
        }}
      >
        <AgGridReact
          columnDefs={defs}
          rowData={albums}
          onGridReady={ready}
        ></AgGridReact>
      </div>
    </div>
  );
};

export default Table;

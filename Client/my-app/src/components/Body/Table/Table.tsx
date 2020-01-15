import React from "react";
import { AgGridReact } from "ag-grid-react";
import "ag-grid-community/dist/styles/ag-grid.css";
import "ag-grid-community/dist/styles/ag-theme-balham.css";
import "ag-grid-community/dist/styles/ag-theme-balham-dark.css";
import { Response } from "../Body";
import "../Style.css";
import { useTable, useSortBy } from "react-table";

// Make it so that the columns have a custom fit that suits required
const ready = (params: any) => {
  params.api.sizeColumnsToFit();
};

// Function that makes use of AG Grid to display data
const Table = ({ defs, albums }: Response) => {
  // Method for rendering a table using AG Grid
  const {
    getTableProps,
    getTableBodyProps,
    headerGroups,
    rows,
    prepareRow
  } = useTable({ columns: defs, data: albums }, useSortBy);

  return (
    <table {...getTableProps()}>
      <thead>
        {headerGroups.map(headerGroup => {
          return (
            <tr {...headerGroup.getHeaderGroupProps()}>
              {headerGroup.headers.map(column => (
                <th {...column.getHeaderProps(column.getSortByToggleProps())}>
                  {column.render("Header")}
                  <span>
                    {column.isSorted
                      ? column.isSortedDesc
                        ? " *"
                        : " +"
                      : ""}
                  </span>
                </th>
              ))}
            </tr>
          );
        })}
      </thead>
      <tbody {...getTableBodyProps()}>
        {rows.map((row, i) => {
          prepareRow(row);
          return (
            <tr {...row.getRowProps()}>
              {row.cells.map(cell => {
                return <td {...cell.getCellProps()}>{cell.render("Cell")}</td>;
              })}
            </tr>
          );
        })}
      </tbody>
    </table>
  );
};

export default Table;

import React from "react";
import { Response } from "../Body";
import "../Style.css";
import { useTable, useSortBy } from "react-table";

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
                    {column.isSorted ? (column.isSortedDesc ? " *" : " +") : ""}
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

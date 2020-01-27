import React from "react";
import Button from "@material-ui/core/Button";

// For showing information that's related to filtering.
export interface FilterProps {
  onClick: (click: boolean) => void;
  name: string;
}

// Simple button that handles filtering being done
const FilterButton = ({ onClick, name }: FilterProps) => {
  return (
    <Button
      variant="contained"
      color="primary"
      onClick={() => {
        onClick(true);
      }}
    >
      {name}
    </Button>
  );
};

export default FilterButton;

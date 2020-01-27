import React, { useState, useEffect } from "react";
import ModalDisplay from "./ModalDisplay";
import Loading from "./Loading";
import FilterButton from "./FilterButton";
import "./Style.css";

// For a particular kind of response from the server
export interface getGenres {
  loaded: boolean;
  results: Array<string>;
  personName: Array<string>;
}

// A function for the scenario where state needs to be pushed upwards.
export interface containerProps {
  setSubmit: (names: Array<string>) => void;
}

// For an explicit modal container being used
const ModalContainer = ({ setSubmit }: containerProps) => {
  // We need some state to show as an initial point
  const [given, setGiven] = useState<getGenres>({
    loaded: false,
    results: [],
    personName: []
  });

  // Go to the api and fetch the relevant information.
  const getGenres = async () => {
    let resp = await fetch("https://localhost:44369/api/genre");
    let genreData = await resp.json();

    setGiven(
      (prevState: getGenres): getGenres => ({
        loaded: true,
        results: genreData.names,
        personName: prevState.personName
      })
    );
  };

  // Initially, want to make one api call at this point
  useEffect(() => {
    getGenres();
  }, []);

  return (
    <>
      {given.loaded ? (
        <div className="ragged">
          <ModalDisplay
            names={given.results}
            setResults={names => {
              setGiven(
                (prevState: getGenres): getGenres => ({
                  loaded: prevState.loaded,
                  results: prevState.results,
                  personName: names
                })
              );
            }}
            state={given.personName}
          />
          <FilterButton
            onClick={() => {
              setSubmit(given.personName);
            }}
            name="Submit"
          />
        </div>
      ) : (
        <Loading />
      )}
    </>
  );
};

export default ModalContainer;

import React, { useState, useEffect } from "react";
import Loading from "./Loading";
import Table from "./Table/Table";
import "./Style.css";
import FilterModal from "./FilterModal";

// Define the contracts to be used within the code, primarily related to interface calls.
export interface Tracks {
  id: number;
  name: string;
}

export interface Album {
  id: number;
  name: string;
  tracks: Array<Tracks>;
}

export interface columnDefs {
  Header: string;
  accessor: string;
  sortable?: boolean;
  filter?: boolean;
}

export interface rowData {
  id: number;
  name: string;
  no: number;
}

export interface Response {
  loaded?: boolean;
  albums: Array<Album>;
  defs: Array<columnDefs>;
}

// Component for dealing with information
const Body: React.FC = () => {
  const [resp, setResp] = useState<Response>({
    loaded: false,
    albums: [],
    defs: [
      { Header: "ID", accessor: "id" },
      { Header: "Album Name", accessor: "name" },
      {
        Header: "Number of Tracks",
        accessor: "no"
      }
    ]
  });

  // Method for getting our data back, will also set as appropriate
  const getAlbums = async () => {
    let resp = await fetch("https://localhost:44369/api/album");
    let albData = await resp.json();
    // Do a map to get the result
    let useAlb = albData.map(
      (x: Album): rowData => ({ id: x.id, name: x.name, no: x.tracks.length })
    );
    // Now set the new information as required
    setResp(
      (prevState: Response): Response => ({
        loaded: true,
        albums: useAlb,
        defs: prevState.defs
      })
    );
  };

  // Making the API call to do the filtering on the data.
  const performFiltering = async (names: Array<string>) => {
    // Set the response so that nothing is now loaded
    console.log(names);
    setResp(
      (prevState: Response): Response => ({
        loaded: false,
        albums: prevState.albums,
        defs: prevState.defs
      })
    );
    let resp = await fetch("https://localhost:44369/api/genre", {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json"
      },
      body: JSON.stringify({
        names: names
      })
    });
    let albData = await resp.json();
    // Do a map to get the result
    let useAlb = albData.map(
      (x: Album): rowData => ({ id: x.id, name: x.name, no: x.tracks.length })
    );
    // Now set the new information as required
    setResp(
      (prevState: Response): Response => ({
        loaded: true,
        albums: useAlb,
        defs: prevState.defs
      })
    );
  };

  // Actually call our method
  useEffect(() => {
    getAlbums();
  }, []);

  // Do our basic return with this information, based on a conditional result
  return (
    <div className="ragged">
      {resp.loaded ? (
        <>
          <FilterModal
            performApi={filter => {
              performFiltering(filter);
            }}
          />
          <Table defs={resp.defs} albums={resp.albums} />
        </>
      ) : (
        <Loading />
      )}
    </div>
  );
};

export default Body;

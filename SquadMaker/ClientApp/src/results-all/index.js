import React from 'react';
import { AgGridReact } from 'ag-grid-react';
import 'ag-grid-community/dist/styles/ag-grid.css';
import 'ag-grid-community/dist/styles/ag-theme-balham.css';

const ShowAllPlayers = (props) => {

  return (
    <div
      className="ag-theme-balham"
      style={{ height: '400px', width: '800px' }}
    >
    <div className="col-md-12 mt-5 ml-1 table-description">All Players</div>
        
      <AgGridReact
        columnDefs={props.columnDefs}
        rowData={props.rowData}>
      </AgGridReact>
    </div>
  )
}

export default ShowAllPlayers;

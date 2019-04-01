import React, { Component } from 'react';
import './main-page.css';
import Header from './header';
import ShowAllPlayers from '../results-all';
import ShowAllTeams from '../result-teams';
import 'ag-grid-community/dist/styles/ag-grid.css';
import 'ag-grid-community/dist/styles/ag-theme-balham.css';


class App extends Component {
  state = {}


  componentDidMount() {
    this.fetchConfiguration();
    if (this.state.pageLoaded === false) {
      this.clearAllTeams();
      this.setState({ NumberOfTeams: 6 }) //initial value
      this.setState({ pageLoaded: true });
    }

  }

  fetchConfiguration = () => {
    fetch('./configuration.json')
      .then(rsp => rsp.json())
      .then(config => {
        this.config = config;
        this.setState({ config: config });
      })
  }


  loadJson=(url)=> {

    var myHeaders = new Headers();
    myHeaders.append('Content-Type', 'application/json');
    myHeaders.append('Access-Control-Allow-Origin', '*');
    myHeaders.append('Access-Control-Allow-Credentials' , true );
    myHeaders.append('Access-Control-Allow-Headers', '*');
    
    var myInit = {
      method: 'GET',
      headers: myHeaders,
      mode: 'cors',
    };

    const myRequest = new Request(url,myInit);

    return fetch(myRequest)
      .then(response => {
        if (response.status == 200) {
          return response.json();
        } else {
          throw Error(response.statusText);
        }
      })
  }


  createTeams=() =>{
    if (!this.state.NumberOfTeams)
    {
      console.log("Number of players not defined!");
      return;
    }

    return this.loadJson("api/squad/" + this.state.NumberOfTeams)
    .then(allTeamsAndBench => {
        this.allTeamsAndBench = allTeamsAndBench;
        this.setState({ clear: false })
        this.setState({ teams: true })
        this.filterAllTeams();
        this.setState({ allTeamsAndBench })
      })
      .catch(err => {
         throw err;
        }
      );
  }

  showPlayers=() =>{
    return this.loadJson("api/players")
    .then(allPlayers => {
      this.allPlayers = allPlayers;
      this.setState({ teams: false });
      this.setState({ clear: true });
      this.setState({ allPlayers })
      })
      .catch(err => {
         throw err;
        }
      );
  }

  filterAllTeams = () => {
    const allTeams = this.allTeamsAndBench.map(
      team => team.players.map((member) => {
        return {...member}
      })
    )
    this.setState({ allTeams });
  }

  createTables = () => {
    let rows = [];
    if (!this.state.allTeams)
      return null;

    var count = Object.keys(this.state.allTeams).length-1; //starts with 0, not 1

    this.state.allTeams.map((team, index) =>
      rows.push(<ShowAllTeams 
        columnDefs={this.state.config.columnDefs} 
        rowData={team} 
        name = {count===index? "Bench":"Team " + (index+1)} 
    />));

    return rows;
  }


  updateNumber = (e) => {
    const val = e.target.value;
    // If the current value passes the validity test then apply that to state
    if (e.target.validity.valid) this.setState({ NumberOfTeams: e.target.value });
  }


  render() {
    let activeComponent = null;
    if (this.state.clear === true && this.state.teams === false) {
      activeComponent = <ShowAllPlayers columnDefs={this.state.config.columnDefs} rowData={this.state.allPlayers} />;
    }
    if (this.state.clear === false && this.state.teams === true) {
      activeComponent = this.createTables();
    }


    return (
      <div className="container">
        <Header subtitle="Squad Maker" />
        <label htmlFor="squadsNo">Number of squads:</label>
        <input type='number' value={this.state.NumberOfTeams} onChange={this.updateNumber} pattern="^([1-3][0-9]|[1-9]|40)$" placeholder = "1-40" />
        <button onClick={this.createTeams} >Create Squads </button>
        <button onClick={this.showPlayers} >Show Players</button>
        {activeComponent}
      </div>
    );
  }
}

export default App;

import React, { Component } from 'react';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { movies: [], loading: true, newMovie: { name: '', year: '' } };
    this.getAllMovies = this.getAllMovies.bind(this);
    this.deleteMovie = this.deleteMovie.bind(this);
    this.nameChange = this.nameChange.bind(this);
    this.yearChange = this.yearChange.bind(this);
    this.insertMovie = this.insertMovie.bind(this);
  }

  componentDidMount() {
    this.getAllMovies();
  }

  getAllMovies() {
    fetch('api/Movies')
      .then(response => response.json())
      .then(data => {
        this.setState({ ...this.state, movies: data, loading: false });
      });
  }

  deleteMovie(id) {
    const formData = new FormData();
    return fetch(`api/Movies/${id}`, {
      method: 'DELETE',
      body: formData
    }).then(() => this.getAllMovies());
  }

  insertMovie(movie) {
    return fetch(`api/Movies`, {
      method: 'POST',
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({ ...movie })
    }).then(() => {
      this.state = { ...this.state, newMovie: { name: '', year: '' } };
      this.getAllMovies()
    });
  }

  nameChange(event) {
    this.setState({ ...this.state, newMovie: { ...this.state.newMovie, name: event.target.value } });
  }

  yearChange(event) {
    this.setState({ ...this.state, newMovie: { ...this.state.newMovie, year: event.target.value } });
  }

  renderMoviesTable(movies) {
    return (
      <table className='table table-striped'>
        <thead>
          <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Year</th>
            <th>Delete</th>
          </tr>
        </thead>
        <tbody>
          {movies.map(movie =>
            <tr key={movie.id}>
              <td>{movie.id}</td>
              <td>{movie.name}</td>
              <td>{movie.year}</td>
              <td><button onClick={() => this.deleteMovie(movie.id)}>X</button></td>
            </tr>
          )}
          <tr>
            <td></td>
            <td><input type="text" value={this.state.newMovie.name} onChange={this.nameChange} /> </td>
            <td><input type="text" value={this.state.newMovie.year} onChange={this.yearChange} /> </td>
            <td><button onClick={() => this.insertMovie(this.state.newMovie)}>+</button></td>
          </tr>
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : this.renderMoviesTable(this.state.movies);
    return (
      <div>
        <h1>Table Movies</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }
}


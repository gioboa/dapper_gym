import React, { Component } from 'react';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { movies: [], loading: true };
    this.getAllMovies = this.getAllMovies.bind(this);
    this.deleteMovie = this.deleteMovie.bind(this);
  }

  componentDidMount() {
    this.getAllMovies();
  }

  getAllMovies() {
    fetch('api/Movies')
      .then(response => response.json())
      .then(data => {
        this.setState({ movies: data, loading: false });
      });
  }

  deleteMovie(id) {
    const formData = new FormData();
    return fetch(`api/Movies/${id}`, {
      method: 'DELETE',
      body: formData
    }).then(() => this.getAllMovies());
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


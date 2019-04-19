using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Dapper;

[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase
{
  IRepository<Movie> moviesRepository = null;

  public MoviesController()
  {
    moviesRepository = new MoviesRepository();
  }

  [HttpGet]
  public IActionResult Get()
  {
    IList<Movie> movies = moviesRepository.GetAll();

    return Ok(movies);
  }

  [HttpGet("{id}", Name = "Get")]
  public IActionResult Get(int id)
  {
    Movie movie = moviesRepository.GetById(id);

    if (movie != null)
    {
      return Ok(movie);
    }
    return NotFound();
  }

  [HttpPost]
  public IActionResult Post(Movie movie)
  {
    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }

    if (true == moviesRepository.Add(movie))
    {
      return Ok(movie);
    }

    return BadRequest();
  }

  [HttpPut("{id}")]
  public IActionResult Put(int id, Movie movie)
  {
    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }

    movie.Id = id;
    var result = moviesRepository.Update(movie);

    if (result == true)
    {
      return Ok(movie);
    }

    return NotFound();
  }

  [HttpDelete("{id}")]
  public IActionResult Delete(int id)
  {
    if (id <= 0)
    {
      return BadRequest("invalid id");
    }

    var result = moviesRepository.Delete(id);

    if (result == true)
    {
      return Ok();
    }

    return NotFound();
  }
}
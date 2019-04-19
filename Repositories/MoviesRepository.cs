using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Dapper;
using test_dapper;

public class MoviesRepository : IRepository<Movie>
{
  private IDbConnection dbConnection = null;

  public MoviesRepository()
  {
    dbConnection = new SqlConnection(ConfigReader.ConnectionString);
  }

  public bool Add(Movie book)
  {
    var result = false;
    try
    {
      string sql = ConfigReader.InsertCommand;
      var count = dbConnection.Execute(sql, book);
      result = count > 0;
    }
    catch { }

    return result;
  }

  public List<Movie> GetAll()
  {
    string sql = ConfigReader.ReadAllCommand;
    return dbConnection.Query<Movie>(sql).ToList();
  }

  public Movie GetById(int id)
  {
    Movie movie = null;
    string sql = ConfigReader.ReadOneCommand;
    var queryResult = dbConnection.Query<Movie>(sql, new { Id = id });

    if (queryResult != null)
    {
      movie = queryResult.FirstOrDefault();
    }
    return movie;
  }

  public bool Update(Movie movie)
  {
    string sql = ConfigReader.UpdateCommand;
    var count = dbConnection.Execute(sql, movie);
    return count > 0;
  }

  public bool Delete(int id)
  {
    string sql = ConfigReader.DeleteCommand;
    var count = dbConnection.Execute(sql, new { Id = id });
    return count > 0;
  }
}


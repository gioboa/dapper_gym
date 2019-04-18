using Dapper;
using System;
using System.Data.SqlClient;
using System.Linq;
public interface IDapperManager
{
  IDetail[] getMovies();
}

public class DapperManager : IDapperManager
{

  public IDetail[] getMovies()
  {
    string sql = "SELECT TOP (1000) [Id],[Name],[Year] FROM [MoviesDB].[dbo].[Movies]";

    using (var connection = new SqlConnection("Server=localhost;Database=MoviesDB;User Id=sa;Password=Passw0rd!"))
    {
      return connection.Query<IDetail>(sql).ToArray();
    }
  }

}
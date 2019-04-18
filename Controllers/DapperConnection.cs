using Dapper;
using System;
using System.Data.SqlClient;
using System.Linq;

public class IDetail
{
  public int Id { get; set; }
  public string Name { get; set; }
  public int Year { get; set; }
}
public interface IDapperManager
{
  IDetail[] getRows();
}

public class DapperManager : IDapperManager
{

  public IDetail[] getRows()
  {
    string sql = "SELECT TOP (1000) [Id],[Name],[Year] FROM [MoviesDB].[dbo].[Movies]";

    using (var connection = new SqlConnection("Server=localhost;Database=MoviesDB;User Id=sa;Password=Passw0rd!"))
    {
      var row = connection.Query<IDetail>(sql).ToArray();
      return row;
    }
  }

}
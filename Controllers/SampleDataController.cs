using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace test_dapper.Controllers
{
  [Route("api/[controller]")]
  public class DapperDataController : Controller
  {
    private readonly IDapperManager _dapperManager;
    public DapperDataController(IDapperManager dapperManager)
    {
      _dapperManager = dapperManager;
    }

    [HttpGet("[action]")]
    public IEnumerable<IDetail> Movies()
    {
      var rng = new Random();
      var summaries = _dapperManager.getMovies();
      return Enumerable.Range(1, 3).Select(index => new IDetail
      {
        Id = summaries[index - 1].Id,
        Year = summaries[index - 1].Year,
        Name = summaries[index - 1].Name
      });
    }
  }
}

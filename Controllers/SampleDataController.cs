using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace test_dapper.Controllers
{
  [Route("api/[controller]")]
  public class SampleDataController : Controller
  {
    private readonly IDapperManager _dapperManager;
    public SampleDataController(IDapperManager dapperManager)
    {
      _dapperManager = dapperManager;
    }

    [HttpGet("[action]")]
    public IEnumerable<WeatherForecast> WeatherForecasts()
    {
      var rng = new Random();
      var summaries = _dapperManager.getRows();
      return Enumerable.Range(1, 3).Select(index => new WeatherForecast
      {
        DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
        TemperatureC = rng.Next(-20, 55),
        Summary = summaries[index-1].Name
      });
    }

    public class WeatherForecast
    {
      public string DateFormatted { get; set; }
      public int TemperatureC { get; set; }
      public string Summary { get; set; }

      public int TemperatureF
      {
        get
        {
          return 32 + (int)(TemperatureC / 0.5556);
        }
      }
    }
  }
}

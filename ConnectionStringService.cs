using System;
using Microsoft.Extensions.Configuration;

namespace Ultranaco.Appsettings
{
  public class ConnectionStringService
  {
    public static IConfiguration Configuration { get; set; }
    public static string Get(string key)
    {
      var connectionString = Configuration.GetConnectionString(key);
      if (connectionString != null)
        return connectionString;

      throw new Exception("ConnectionString Not Found");
    }
  }
}

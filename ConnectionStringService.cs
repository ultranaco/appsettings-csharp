using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
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

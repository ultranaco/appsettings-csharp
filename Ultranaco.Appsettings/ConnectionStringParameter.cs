using System;
using Microsoft.Extensions.Configuration;

namespace Ultranaco.Appsettings
{
  public static class ConnectionStringParameter
  {
    public static IConfiguration Configuration { get; set; }

    public static IConfigurationRoot AttachConnectionString(this IConfigurationRoot configuration)
    {
      ConnectionStringParameter.Configuration = configuration;
      return configuration;
    }

    public static string Get(string key)
    {
      var connectionString = Configuration.GetConnectionString(key);
      if (connectionString != null)
        return connectionString;

      throw new Exception("ConnectionString Not Found");
    }
  }
}

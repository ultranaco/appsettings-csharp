using System;
using Microsoft.Extensions.Configuration;

namespace Ultranaco.Appsettings
{
  public class AppParameter
  {
    public static T Get<T>(string key, T defaultValue)
    {
      var value = System.Configuration.ConfigurationManager.AppSettings[key];

      if (value != null)
        return (T)Convert.ChangeType(value, typeof(T));

      return defaultValue;
    }

    public static T Get<T>(string key)
    {
      var keyApp = System.Configuration.ConfigurationManager.AppSettings[key];
      if (keyApp == null)
        return default(T);

      return (T)Convert.ChangeType(keyApp, typeof(T));
    }

    public static IConfigurationRoot LoadAppSettings(string filename = "appsettings.json")
    {
      var builder = new ConfigurationBuilder()
           .SetBasePath(AppContext.BaseDirectory)
           .AddJsonFile("appsettings.json")
           .AddEnvironmentVariables();

      IConfigurationRoot configuration = builder.Build();
      ConnectionStringService.Configuration = configuration;
      return configuration;
    }
  }
}

using System;
using Microsoft.Extensions.Configuration;

namespace Ultranaco.Appsettings
{
  public static class AppKeyParameter
  {
    public static IConfiguration Configuration { get; set; }
    public static T Get<T>(string key, T defaultValue)
    {
      var value = Configuration.GetSection(string.Format("AppSettings:{0}", key));

      if (value.Value != null)
      {
        try
        {
          return (T)Convert.ChangeType(value.Value, typeof(T));
        }
        catch(Exception e)
        {
          Console.WriteLine(e.ToString());
          return defaultValue;
        }
      }


      return defaultValue;
    }

    public static IConfigurationRoot AttachApplicationKeys(this IConfigurationRoot configuration)
    {
      AppKeyParameter.Configuration = configuration;
      return configuration;
    }
  }
}

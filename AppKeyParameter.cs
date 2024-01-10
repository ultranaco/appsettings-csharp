using System;
using Microsoft.Extensions.Configuration;

namespace Ultranaco.Appsettings
{
  public class AppKeyParameter
  {
    public static IConfiguration Configuration { get; set; }
    public static T Get<T>(string key, T defaultValue)
    {
      var value = AppKeyParameter.Get<string>(key);

      if (value != null)
        return (T)Convert.ChangeType(value, typeof(T));

      return defaultValue;
    }

    public static T Get<T>(string key)
    {
      var keyApp = AppKeyParameter.Get<string>(key);

      if (keyApp == null)
        return default(T);

      return (T)Convert.ChangeType(keyApp, typeof(T));
    }

    public AttachApplicationKeys(IConfiguration configuration)
    {
      AppKeyParameter.Configuration = configuration;
    }
  }
}

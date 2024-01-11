using Microsoft.Extensions.Configuration;
using Ultranaco.Appsettings;
using NUnit.Framework;

namespace Ultranaco.Appsettings.Test;

public class IntegrationTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test, Order(1)]
    public void GetParameters()
    {
        IConfiguration configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory() + "/../../..")
        .AddJsonFile("appSettings.json")
        .Build()
        .AttachApplicationKeys();

        var parameter = AppKeyParameter.Get("parallelism", 50);

        Assert.Pass();
    }
}
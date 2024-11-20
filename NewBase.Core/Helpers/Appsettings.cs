﻿using NewBase.Core.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace NewBase.Core.Helpers
{
    public static class Appsettings
    {
        public static string GetSettingValue(string Key)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.{Hosting.EnvironmentName}.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            IConfigurationRoot configuration = builder.Build();
            return configuration.GetValue<string>(Key);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.FileExtensions;
using System.IO;

namespace FindForm.Configuration
{
    class Settings
    {
        private static Settings _Current = null;
        public static Settings Current
        {
            get
            {
                if(_Current == null)
                {
                    _Current = new Settings();
                }

                return _Current;
            }
        }

        public static TestConfig TestConfig
        {
            get
            {
                TestConfig result = new TestConfig();
                Current.Config.GetSection("TestCOnfig").Bind(result);
                return result;
            }
        }
        public static string UserName
        {
            get
            {
                return TestConfig.UserName;
            }
        }
        public static string Password
        {
            get
            {
                return TestConfig.Password;
            }
        }
        /*
        public static TestConfig ConfigTest
        {
            get
            {
                return new TestConfig()
                {
                    SiteUrl = "https://subline-test.artsrn.ualberta.ca/",
                    TestEventId = 48
                };
            }
        }
        */
        public IConfigurationRoot Config { get; private set; }

        public Settings()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Config = builder.Build();
        }
    }
}

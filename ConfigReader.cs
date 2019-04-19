using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace test_dapper
{
    public class ConfigReader
    {
        static IConfigurationRoot config = null;
        static string settingsSection = "MoviesRepositorySettings";

        static ConfigReader()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            config = builder.Build();
        }

        public static string ConnectionString
        {
            get
            {
                return config.GetSection(settingsSection).GetValue<string>("DbConnection");
            }
        }

        public static string InsertCommand
        {
            get
            {
                return config.GetSection(settingsSection).GetValue<string>("InsertCommand");
            }
        }

        public static string ReadAllCommand
        {
            get
            {
                return config.GetSection(settingsSection).GetValue<string>("ReadAllCommand");
            }
        }

        public static string ReadOneCommand
        {
            get
            {
                return config.GetSection(settingsSection).GetValue<string>("ReadOneCommand");
            }
        }

        public static string UpdateCommand
        {
            get
            {
                return config.GetSection(settingsSection).GetValue<string>("UpdateCommand");
            }
        }

        public static string DeleteCommand
        {
            get
            {
                return config.GetSection(settingsSection).GetValue<string>("DeleteCommand");
            }
        }
    }
}

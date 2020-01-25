using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MeetingAppDataLayer
{
    
    public class AppSettings
    {
        public AppSettings()
        {
            var config = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(),"appsettings.json");
            config.AddJsonFile(path, false);
            var root = config.Build();
            SqlConnectionString = root.GetSection("MeetingDataConenction:DataConnection").Value;
            SecurityKey = root.GetSection("JSKey").Value;
            HostUrl = root.GetSection("URL").Value;
        }

        public string SqlConnectionString { get; set; }

        public string SecurityKey { get; set; }

        public string HostUrl { get; set; }
    }
}

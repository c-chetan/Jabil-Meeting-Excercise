using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MeetingAppDataLayer.Models;

namespace MeetingAppDataLayer.DBContext
{
    public class MeetDBContext: DbContext
    {
        public class OptionsBuild
        {
            public OptionsBuild()
            {
                appSettings = new AppSettings();
                optionsBuilder = new DbContextOptionsBuilder<MeetDBContext>();
                optionsBuilder.UseSqlServer(appSettings.SqlConnectionString);
                dbOptions = optionsBuilder.Options;

            }

            public DbContextOptionsBuilder<MeetDBContext> optionsBuilder { get; set; }
            
            public DbContextOptions<MeetDBContext> dbOptions { get; set; }

            public AppSettings appSettings { get; set; }
        }

        public static OptionsBuild optionsBld = new OptionsBuild();

        public MeetDBContext(DbContextOptions<MeetDBContext> options): base(options) { }

        public DbSet<User> Users { get; set; }
    }
}

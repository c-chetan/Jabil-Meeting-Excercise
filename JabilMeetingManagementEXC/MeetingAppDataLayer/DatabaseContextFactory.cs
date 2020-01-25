using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MeetingAppDataLayer.DBContext;

namespace MeetingAppDataLayer
{
    class DatabaseContextFactory: IDesignTimeDbContextFactory<MeetDBContext>
    {
        public MeetDBContext CreateDbContext(string[] args)
        {
            AppSettings settings = new AppSettings();
            var optBuilder = new DbContextOptionsBuilder<MeetDBContext>();
            optBuilder.UseSqlServer(settings.SqlConnectionString);

            return new MeetDBContext(optBuilder.Options);
        }
    }
}

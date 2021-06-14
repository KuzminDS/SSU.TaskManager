
using System;
using System.Collections.Generic;
using System.Text;

namespace SSU.TaskManager.Models
{
    public static class AppSettings
    {
        public static string ConnectionString { get; } = $@"Filename=/data/user/0/com.companyname.ssu.taskmanager/files/database.db";

        //public static string ConnectionString { get; } = "Filename=database.db";
    }
}
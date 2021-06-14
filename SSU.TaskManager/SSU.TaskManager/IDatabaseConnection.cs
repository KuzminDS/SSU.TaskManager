using System;
using System.Collections.Generic;
using System.Text;

namespace SSU.TaskManager
{
    public interface IDatabaseConnection
    {
        SQLite.SQLiteConnection DbConnection();
    }
}

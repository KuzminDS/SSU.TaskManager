using System;
using System.Collections.Generic;
using System.Text;

namespace SSU.TaskManager.Models.DaoInterface
{
    public interface IPath
    {
        string GetDatabasePath(string filename);
    }
}

using SSU.TaskManager.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSU.TaskManager.Models.DataAccessInterface
{
    public interface IUsersDataAccess
    {
        IEnumerable<User> GetAll();
        void SaveUser(User userInstance);
        int DeleteUser(User userInstance);
        User GetUserById(int id);
    }
}

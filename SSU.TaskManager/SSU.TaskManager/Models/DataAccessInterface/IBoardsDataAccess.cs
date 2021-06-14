using SSU.TaskManager.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSU.TaskManager.Models.DataAccessInterface
{
    public interface IBoardsDataAccess
    {
        IEnumerable<Board> GetAll();
        void SaveBoard(Board boardInstance);
        int DeleteBoard(Board boardInstance);
        Board GetBoardById(int id);
    }
}

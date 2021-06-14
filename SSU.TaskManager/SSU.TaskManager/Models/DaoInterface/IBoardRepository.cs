
using SSU.TaskManager.Entities;
using System.Collections.Generic;

namespace SSU.TaskManager.Models.DaoInterface
{
    public interface IBoardRepository
    {
        IEnumerable<Board> GetAll();
        Board GetById(int id);
    }
}
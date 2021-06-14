using Microsoft.EntityFrameworkCore;
using SSU.TaskManager.Entities;
using SSU.TaskManager.Models.DaoInterface;
using System;
using System.IO;
using Xamarin.Forms;

namespace SSU.TaskManager.Models.Dao
{
    public class TaskManagerContext : DbContext
    {
        private readonly string _databasePath;

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<User> Users { get; set; }

        //public TaskManagerContext(string databasePath)
        //{
        //    _databasePath = databasePath;
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($@"Filename=/data/user/0/com.companyname.ssu.taskmanager/files/database.db");
            //optionsBuilder.UseSqlite($@"Filename=database.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.
            //    ApplyConfiguration(new TaskConfiguration());
            //modelBuilder.
            //    ApplyConfiguration(new UserConfiguration());
            //modelBuilder.
            //    ApplyConfiguration(new BoardConfiguration());
        }
    }
}

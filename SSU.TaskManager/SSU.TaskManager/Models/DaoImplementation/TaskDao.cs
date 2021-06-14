using Microsoft.Data.Sqlite;
using SSU.TaskManager.Entities;
using SSU.TaskManager.Models.DaoInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSU.TaskManager.Models.DaoImplementation
{
    public class TaskDao : ITaskRepository
    {
        private readonly string _connectionString;

        public TaskDao()
        {
            _connectionString = AppSettings.ConnectionString;
        }

        public void Add(Task entity)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                string queryString =
                        $"insert into Task (Title, Description, DeadLine, BoardId, UserId) " +
                        $"values ('{entity.Title}', '{entity.Description}', '{entity.DeadLine}', {entity.BoardId}, {entity.UserId})";
                using (var command = new SqliteCommand(queryString, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                string queryString =
                        $"delete from Task where Id='{id}'";
                using (var command = new SqliteCommand(queryString, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Task> GetAll()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                string queryString = $"select * from Task";

                var command = new SqliteCommand(queryString, connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new Task
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Title = Convert.ToString(reader["Title"]),
                            Description = Convert.ToString(reader["Description"]),
                            //DeadLine = Convert.ToString(reader["DeadLine"]),
                            UserId = Convert.ToInt32(reader["UserId"]),
                            BoardId = Convert.ToInt32(reader["BoardId"])
                        };
                    }
                }
            }
        }

        public Task GetById(int id)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                string queryString = $"select * from Task where Id='{id}'";

                var command = new SqliteCommand(queryString, connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new Task
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Title = Convert.ToString(reader["Title"]),
                            Description = Convert.ToString(reader["Description"]),
                            //DeadLine = Convert.ToString(reader["DeadLine"]),
                            UserId = Convert.ToInt32(reader["UserId"]),
                            BoardId = Convert.ToInt32(reader["BoardId"])
                        };
                    }
                }
                throw new Exception($"Task with Id={id} doesn't exist");
            }
        }

        public void Update(Task entity)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                string queryString =
                        $"update Task set Title='{entity.Title}', Description='{entity.Description}', DeadLine='{entity.DeadLine}', UserId={entity.UserId}, BoardId={entity.BoardId} " +
                        $"where Id={entity.Id}";
                using (var command = new SqliteCommand(queryString, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
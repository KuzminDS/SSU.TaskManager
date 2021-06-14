using Microsoft.Data.Sqlite;
using SSU.TaskManager.Entities;
using SSU.TaskManager.Models.DaoInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSU.TaskManager.Models.DaoImplementation
{
    public class UserDao : IUserRepository
    {
        private readonly string _connectionString;

        public UserDao()
        {
            _connectionString = AppSettings.ConnectionString;
        }

        public void Add(User entity)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                string queryString =
                        $"insert into User (FirstName, LastName, Login, Password) " +
                        $"values ('{entity.FirstName}', '{entity.LastName}', '{entity.Login}', '{entity.Password}')";
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
                        $"delete from User where Id='{id}'";
                using (var command = new SqliteCommand(queryString, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                string queryString = $"select * from User";

                var command = new SqliteCommand(queryString, connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new User
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            LastName = Convert.ToString(reader["LastName"]),
                            FirstName = Convert.ToString(reader["FirstName"]),
                            Login = Convert.ToString(reader["Login"]),
                            Password = Convert.ToString(reader["Password"])
                        };
                    }
                }
            }
        }

        public User GetById(int id)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                string queryString = $"select * from User where Id='{id}'";

                var command = new SqliteCommand(queryString, connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new User
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            LastName = Convert.ToString(reader["LastName"]),
                            FirstName = Convert.ToString(reader["FirstName"]),
                            Login = Convert.ToString(reader["Login"]),
                            Password = Convert.ToString(reader["Password"])
                        };
                    }
                }
                throw new Exception($"User with Id={id} doesn't exist");
            }
        }

        public void Update(User entity)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                string queryString =
                    $"update User set LastName='{entity.LastName}', FirstName='{entity.FirstName}', Login='{entity.Login}', Password='{entity.Password}' " +
                    $"where Id={entity.Id}";
                using (var command = new SqliteCommand(queryString, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
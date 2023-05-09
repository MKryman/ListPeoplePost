using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_03_27.Data
{
    public class PersonData
    {
        private string _connectionString;

        public PersonData(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddPeople(List<Person> people)
        {
            var connection = new SqlConnection(_connectionString);
            var command = connection.CreateCommand();
            foreach (Person p in people)
            {
                command.CommandText="INSERT INTO People(FirstName, LastName, Age) " +
                    "VALUES(@fName, @lName, @age)";
                command.Parameters.AddWithValue("@fName", p.FirstName);
                command.Parameters.AddWithValue("@lName", p.LastName);
                command.Parameters.AddWithValue("age", p.Age);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Person> GetAllPeople()
        {
            var connection = new SqlConnection(_connectionString);
            var command = connection.CreateCommand();
            command.CommandText="SELECT * FROM People";
            connection.Open();
            List<Person> people = new();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                people.Add(new Person
                {
                    Id = (int)reader["Id"],
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Age = (int)reader["Age"]
                });
            }

            return people;
        }
    }
}

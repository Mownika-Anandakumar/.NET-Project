using MySql.Data.MySqlClient;
using System;

namespace Student_DB
{
    internal class StudentController
    {
        private string connectionString = "Server=localhost;Port=3305;Database=student_db;Uid=root;Pwd= Mowni;";
 
        public void InsertStudent(Student s)
        {
            using var conn = new MySqlConnection(connectionString);
            conn.Open();
            string query = @"INSERT INTO students (name, age, department, email, location) 
                             VALUES (@name, @age, @dept, @mail, @loc)";
            var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", s.Name);
            cmd.Parameters.AddWithValue("@age", s.Age);
            cmd.Parameters.AddWithValue("@dept", s.Department);
            cmd.Parameters.AddWithValue("@mail", s.Email);
            cmd.Parameters.AddWithValue("@loc", s.Location);
            cmd.ExecuteNonQuery();
            Console.WriteLine("✅ Student Inserted");
        }

        public void ViewAllStudents()
        {
            using var conn = new MySqlConnection(connectionString);
            conn.Open();
            string query = "SELECT * FROM students";
            var cmd = new MySqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader["id"]}, Name: {reader["name"]}, Age: {reader["age"]}, Dept: {reader["department"]}, Email: {reader["email"]}, Location: {reader["location"]}");
            }
        }
    }
}

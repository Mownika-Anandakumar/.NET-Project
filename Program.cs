using System;

namespace Student_DB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentController controller = new StudentController();

            // Sample student data
            Student student = new Student
            {
                Name = "Thavasi",
                Age = 21,
                Department = "IT",
                Email = "mowni@example.com",
                Location = "Madurai"
            };

            controller.InsertStudent(student);

            Console.WriteLine("Done");
        }
    }
}

using TraineeTask;
using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var students = Student.Fill();
        var studentIds = students.Select(s => s.Id).ToList();
        var subjectNames = new List<string> { "Math", "Physics", "Biology", "History", "Chemistry", "Ukrainian" };

        var allSubjects = Subject.Fill(studentIds, subjectNames);

        foreach (var student in students)
        {
            student.SetSubjects(allSubjects);
            student.CalculateAverageGrade();
            student.SetGrant();
        }

        while (true)
        {
            Console.Write("Enter Student Id to display details: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int studentId))
            {
                Console.WriteLine("Please enter a valid numeric Student Id.");
                continue;
            }

            var selectedStudent = students.FirstOrDefault(s => s.Id == studentId);

            if (selectedStudent != null)
            {
                DisplayStudentDetails(selectedStudent);
            }
            else
            {
                Console.WriteLine($"Student with Id '{input}' not found.");
            }

            Console.WriteLine("\nDo you want to search for another student? (y/n)");
            string continueSearch = Console.ReadLine();
            if (continueSearch?.ToLower() != "y")
            {
                break;
            }
        }
    }

    static void DisplayStudentDetails(Student student)
    {
        Console.WriteLine($"\nStudent: {student.FirstName} {student.SecondName} \nAge: {student.Age} " +
            $"\nAverage Grade: {student.AverageGrade:F0}" +
            $"\nGrant: {student.Grant}");

        Console.WriteLine("\nSubjects:");
        foreach (var subject in student.Subjects.OrderBy(s => s.Name))
        {
            Console.WriteLine($"- {subject.Name}, Grade: {subject.Grade}, Date: {subject.Date.ToShortDateString()}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeTask
{
    internal class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int Age { get; set; }
        public List<Subject> Subjects { get; set; } = new List<Subject>();
        public Subject Grade { get; set; }
        public double AverageGrade { get; set; }
        public GrantType Grant { get; set; }

        public enum GrantType
        {
            None,
            Regular,
            Increased
        }

        public static List<Student> Fill()
        {
            return new List<Student>
            {
                new Student { Id = 1, FirstName = "Mark", SecondName = "Osafiychuk", Age = 19 },
                new Student { Id = 2, FirstName = "Liza", SecondName = "Kolodiy", Age = 18},
                new Student { Id = 3, FirstName = "Ivan", SecondName = "Chepil", Age = 20},
                new Student { Id = 4, FirstName = "Mari", SecondName = "Kravets", Age = 21}
            };
        }

        public void SetSubjects(List<Subject> allSubjects)
        {
            Subjects = Subject.GetByStudentId(allSubjects, Id);
        }

        public void CalculateAverageGrade()
        {
            AverageGrade = Math.Round(Subjects.Average(s => s.Grade));
        }
        public void SetGrant()
        {
            if (AverageGrade < 60)
            {
                Grant = GrantType.None;
            }
            else if (AverageGrade >= 60 && AverageGrade < 90)
            {
                Grant = GrantType.Regular;
            }
            else
            {
                Grant = GrantType.Increased;
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeTask
{
    internal class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StudentId { get; set; }
        public int Grade { get; set; }
        public DateTime Date { get; set; }


        public static List<Subject> Fill(List<int> studentIds, List<string> subjectNames)
        {
            var random = new Random();
            var subjects = new List<Subject>();
            int idCounter = 1;

            foreach (var studentId in studentIds)
            {
                foreach (var subjectName in subjectNames)
                {
                    subjects.Add(new Subject
                    {
                        Id = idCounter++,
                        Name = subjectName,
                        StudentId = studentId,
                        Grade = random.Next(60, 100),
                        Date = GetRandomDate(new DateTime(2024, 1, 1), DateTime.Now)
                    });
                }
            }

            return subjects;
        }
        private static DateTime GetRandomDate(DateTime startDate, DateTime endDate)
        {
            var random = new Random();
            int range = (endDate - startDate).Days;
            return startDate.AddDays(random.Next(range));
        }

        public static List<Subject> GetByStudentId(List<Subject> subjects, int studentId)
        {
            return subjects.Where(s => s.StudentId == studentId).ToList();
        }
    }
}


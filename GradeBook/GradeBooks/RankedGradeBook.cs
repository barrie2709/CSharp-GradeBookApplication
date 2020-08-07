using System;
namespace GradeBook.GradeBooks
{
    public class RankedGradeBook:BaseGradeBook
    {
        public RankedGradeBook(string name):base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            int numberOfStudents = Students.Count;
            int twentyPercent = numberOfStudents / 5;
            int counterBigger = 0;

            if (numberOfStudents < 5) throw new InvalidOperationException();

            foreach(Student student in Students)
            {
                if (student.AverageGrade > averageGrade) counterBigger++;
            }
            if (counterBigger < twentyPercent) return 'A';
            if (counterBigger < 2 * twentyPercent) return 'B';
            if (counterBigger < 3 * twentyPercent) return 'C';
            if (counterBigger < 4 * twentyPercent) return 'D';

            return 'F';
            
        }

        public override void CalculateStatistics()
        {
            int numberOfStudents = Students.Count;

            if(numberOfStudents<5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order " +
                    "to properly calculate a student's overall grade.");
                return;

            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            int numberOfStudents = Students.Count;

            if(numberOfStudents<5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades" +
                    "in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}

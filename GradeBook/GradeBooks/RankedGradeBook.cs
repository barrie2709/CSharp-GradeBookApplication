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
    }
}

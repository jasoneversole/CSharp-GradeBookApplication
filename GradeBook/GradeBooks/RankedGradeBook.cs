using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked Grading requires a minimum of 5 students to work");
            }

            int rankCount = Convert.ToInt32(Students.Count * 0.20f);
            List<Student> sortedStudents = Students.OrderByDescending(x => x.AverageGrade).ToList();            
            
            if (sortedStudents[rankCount-1].AverageGrade <= averageGrade)
            {
                return 'A';
            }
            else if(sortedStudents[(rankCount * 2) - 1].AverageGrade <= averageGrade)
            {
                return 'B';
            }
            else if (sortedStudents[(rankCount * 3) - 1].AverageGrade <= averageGrade)
            {
                return 'C';
            }
            else if (sortedStudents[(rankCount * 4) - 1].AverageGrade <= averageGrade)
            {
                return 'D';
            }

            return 'F';
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}

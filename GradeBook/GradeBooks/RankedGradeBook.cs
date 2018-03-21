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
            
            for (int i = 1; i < (sortedStudents.Count + 1); i++)
            {
                if (sortedStudents[i - 1].AverageGrade == averageGrade)
                {
                    if(i <= rankCount)
                    {
                        return 'A';
                    }
                    else if(i <= rankCount*2)
                    {
                        return 'B';
                    }
                    else if (i <= rankCount * 3)
                    {
                        return 'C';
                    }
                    else if (i <= rankCount * 4)
                    {
                        return 'D';
                    }
                }
            }

            return 'F';
        }
    }
}

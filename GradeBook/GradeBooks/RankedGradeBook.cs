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
            Students = Students.OrderByDescending(x => x.AverageGrade).ToList();            

            for (int i = 0; i < Students.Count; i++)
            {
                if (Students[i].AverageGrade == averageGrade)
                {
                    if((i + 1) <= rankCount)
                    {
                        return 'A';
                    }
                    else if((i + 1) <= rankCount*2)
                    {
                        return 'B';
                    }
                    else if ((i + 1) <= rankCount * 3)
                    {
                        return 'C';
                    }
                    else if ((i + 1) <= rankCount * 4)
                    {
                        return 'D';
                    }
                }
            }

            return 'F';
        }
    }
}

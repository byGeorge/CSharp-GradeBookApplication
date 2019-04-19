using GradeBook.Enums;
using System;
using System.Linq;

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
			if (Students.Count < 5)
				throw new InvalidOperationException("Ranked grading requires a minimum of 5 students to work.");

			var gradeList = Students.OrderByDescending(e => e.AverageGrade);
			int position = 0;
			foreach (Student grade in gradeList)
			{
				if (averageGrade == grade.AverageGrade)
					break;
				else
					position++;
			}
			double rank = position / Students.Count;
			if (rank > .8)
				return 'A';
			else if (rank > .6)
				return 'B';
			else if (rank > .4)
				return 'C';
			else if (rank > .2)
				return 'D';
			return 'F';
		}
	}
}

using GradeBook.Enums;
using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
	public class RankedGradeBook : BaseGradeBook
	{
		public RankedGradeBook(string name, bool weighted) : base(name, weighted)
		{
			Type = GradeBookType.Ranked;
			IsWeighted = weighted;
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
			double rank = ((double) position) / ((double) Students.Count);
			if (rank < 0.2)
				return 'A';
			else if (rank < 0.4)
				return 'B';
			else if (rank < 0.6)
				return 'C';
			else if (rank < 0.8)
				return 'D';
			else
				return 'F';
		}

		public override void CalculateStatistics()
		{
			if (Students.Count < 5)
			{
				Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
				return;
			}
			base.CalculateStatistics();
		}

		public override void CalculateStudentStatistics(string name)
		{
			if (Students.Count < 5)
			{
				Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
				return;
			}
			base.CalculateStudentStatistics(name);
		}
	}
}

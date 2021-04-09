using System;

namespace Library.Models.Implementations
{
    public class Student : IFollower
    {
		public Student(ILeader teacher)
		{
			Leader = teacher;
		}

		public ILeader Leader { get; }
    }
}

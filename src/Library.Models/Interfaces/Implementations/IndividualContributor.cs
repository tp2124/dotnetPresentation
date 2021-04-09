using System;

namespace Library.Models.Implementations
{
	public class IndividualContributor : IFollower
	{
		public IndividualContributor(ILeader lead)
		{
			Leader = lead;
		}

		public ILeader Leader { get; }
	}
}

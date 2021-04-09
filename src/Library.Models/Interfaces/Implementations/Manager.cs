using System.Collections.Generic;
using System.Linq;

namespace Library.Models.Implementations
{
    public class Manager : ILeader
    {
		private ICollection<IFollower> _followers;
		public Manager()
		{
			_followers = new List<IFollower>();
		}

		public Manager(IEnumerable<IFollower> followers)
		{
			_followers = followers.ToList();
		}

		public void AddDirectReport(IFollower directReport)
		{
			_followers.Add(directReport);
		}

		public IEnumerable<IFollower> Followers => _followers;
    }
}

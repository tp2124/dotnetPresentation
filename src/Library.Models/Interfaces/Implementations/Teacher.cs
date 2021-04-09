using System.Collections.Generic;
using System.Linq;

namespace Library.Models.Implementations
{
	public class Teacher : ILeader
	{
		private ICollection<IFollower> _followers;
		public Teacher()
		{
			_followers = new List<IFollower>();
		}

		public Teacher(IEnumerable<IFollower> followers)
		{
			_followers = followers.ToList();
		}

		public IEnumerable<IFollower> Followers => _followers;
	}
}

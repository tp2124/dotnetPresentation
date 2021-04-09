using System.Collections.Generic;

namespace Library.Models
{
    public interface ILeader
    {
		IEnumerable<IFollower> Followers { get; }
    }
}

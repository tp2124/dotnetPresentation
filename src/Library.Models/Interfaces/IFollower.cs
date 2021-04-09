using System;

namespace Library.Models
{
    public interface IFollower
    {
		ILeader Leader { get; }
    }
}

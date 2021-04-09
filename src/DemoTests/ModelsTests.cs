using Library.Models;
using Library.Models.Implementations;
using System.Collections.Generic;
using Xunit;

namespace DemoTests
{

	public class ModelsTests
	{
		[Theory]
		[InlineData(true)]
		[InlineData(false)]
		public void SuccessfulTest(bool compareForEquals)
		{
			Manager sharedManager = new Manager();
			IndividualContributor ic1 = new IndividualContributor(sharedManager);
			IndividualContributor ic2 = new IndividualContributor(sharedManager);

			if (compareForEquals)
			{
				Assert.True(ic1.Leader == ic2.Leader);
			}
			else
			{
				Assert.False(ic1.Leader != ic2.Leader);
			}
		}
	}
}

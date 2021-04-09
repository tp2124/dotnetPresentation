using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApplication.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
    public class DemoController : Controller
	{
		// Demo of a comment!
		// at URI /api/Demo/RunDemo
		[HttpGet("RunDemo")]
		public ActionResult<IEnumerable<string>> Get()
		{
			return new string[] { "value1", "value2" };
		}

	}
}
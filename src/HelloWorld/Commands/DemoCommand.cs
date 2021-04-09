using System;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;

namespace HelloWorld.Commands
{
    public class DemoCommand
    {
		private readonly ILogger _logger;
		/// <summary>
		///		It's best practice to create a IProgramContext to wrap the explicit usage of CommandLineApplicaiton
		///		to allow for testing/mocking of even the commands.
		/// </summary>
		/// <param name="app"></param>
		public DemoCommand (CommandLineApplication app, ILoggerFactory loggerFactory)
		{
			if (loggerFactory == null) throw new ArgumentNullException(nameof(loggerFactory));
			_logger = loggerFactory.CreateLogger(nameof(DemoCommand));
			Argument = app.Argument("demoArg", "Demo Application argument");
			CommandObject = app.Command("demo", config =>
			{
				config.Description = $"A great command to show off the description.";
				// Do you want to make this asynchronous? No problem
				//config.OnExecute(async () =>
				config.OnExecute(() =>
				{
					using (_logger.BeginScope(nameof(Execute)))
					{
						return Execute();
					}
				});
			});
		}

		public CommandArgument Argument { get; }
		public CommandLineApplication CommandObject { get; }

		private int Execute()
		{
			_logger.Log(LogLevel.Trace, "Running the demo command");
			_logger.Log(LogLevel.Information, "Hello World from command!");
			if (!string.IsNullOrWhiteSpace(Argument.Value))
			{
				_logger.Log(LogLevel.Debug, $"The argument: {Argument.Name} is set to: {Argument.Value}");
			}
			else
			{
				_logger.Log(LogLevel.Debug, $"The argument: {Argument.Name} is not set");
			}

			_logger.Log(LogLevel.Warning, "Example of an warning color");
			_logger.Log(LogLevel.Error, "Example of an error color");
			_logger.Log(LogLevel.Critical, "Example of a critical color");
			return 0;
		}
    }
}

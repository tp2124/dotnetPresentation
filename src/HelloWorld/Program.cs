using System;
using System.Reflection;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;

using NLog;
using NLog.Config;
using NLog.Extensions.Logging;
using NLog.Targets;

namespace HelloWorld
{
	class Program
	{
		static int Main(string[] args)
		{
			//*********************************************************************************
			// Create our initial Application.
			CommandLineApplication app = new CommandLineApplication
			{
				Name = "HelloWorldConsole",
				Description = ".NET Core console with argument parsing."
			};

			//*********************************************************************************
			// Setup the Command Line expectations. This can be split up into multiple classes
			// for when Command or Option logic wants to be protected or gets more complicated.
			// Only a single command can be issued. Commands can be thought of as different operations.
			app.HelpOption("-?|-h|--help");
			app.VersionOption("-v|--version",
				$"Version: {Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion}");

			LogManager.Configuration = GetNLogConfig();
			ILoggerFactory loggerFactory = new LoggerFactory()
				.AddNLog(new NLogProviderOptions { EventIdSeparator = "|" });

			InitializeCommands(app, loggerFactory);

			//*********************************************************************************
			// Set the Execute Action if no command is hit. it's best practice to print help here 
			// instead of going into something that should be split into proper Command
			app.OnExecute(() =>
			{
				app.ShowHelp();
				return 0;
			});

			//*********************************************************************************
			// Execute already!
			return app.Execute(args);
		}

		/// <summary>
		///		Create a configuration to log to both a file and a colored console.
		/// </summary>
		/// <returns></returns>
		private static LoggingConfiguration GetNLogConfig()
		{
			var fileTarget = new FileTarget("logfile")
			{
				FileNameKind = FilePathKind.Absolute,
				FileName = $"D:/Logs/application.log",
				ArchiveFileName = $"D:/Logs/application.#.log",
				ArchiveEvery = FileArchivePeriod.Day,
				ArchiveNumbering = ArchiveNumberingMode.DateAndSequence,
				ConcurrentWrites = true,
				KeepFileOpen = true,
				MaxArchiveFiles = 14,
				Layout = "${longdate}|${logger} ${ndc}|${uppercase:${level}}|${message}"
			};

			var consoleTarget = new ColoredConsoleTarget("console")
			{
				Layout = "${processtime:format=mm\\:ss.fff} | ${level:uppercase=true} | ${message}"
			};

			var config = new LoggingConfiguration();
			config.AddTarget(consoleTarget);
			config.AddTarget(fileTarget);
			config.AddRuleForAllLevels(consoleTarget);
			config.AddRuleForAllLevels(fileTarget);

			return config;
		}

		private static void InitializeCommands(CommandLineApplication app, ILoggerFactory loggerFactory)
		{
			Activator.CreateInstance(typeof(Commands.DemoCommand), app, loggerFactory);
		}
	}
}

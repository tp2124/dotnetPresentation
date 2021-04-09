# hello-world
Demo for EDG
These steps will require 2017 to be installed prior to running.

## dotnet command line initialization steps
See Documentation for cli commands: https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new?tabs=netcore21

### Steps to Create Project
1. `dotnet new console -n HelloWorld`
2. `dotnet new mstests -n DemoTests`
3. `dotnet new sln -n DemoApplications`
4. `dotnet sln DemoApplications.sln add DemoTests`
5. `dotnet sln DemoApplications.sln add HelloWorld`

### Add References to NuGet Packages
In Visual Studio 2017, right click a project-> Manage NuGet Packages... 
From there, you can search in any configured NuGet package repositories for packages.

By command line, many commands can be found by looking at the public NuGet storage. Here is an example for Microsoft.Extensions.ComamndLineUtils: 
https://www.nuget.org/packages/Microsoft.Extensions.CommandLineUtils/
See the tab for ".NET CLI", and it will be the same as below.

This command is from src/
* `dotnet add HelloWorld/HelloWorld.csproj package Microsoft.Extensions.CommandLineUtils --version 1.1.1`

The other NuGet package references were found by doing the same methods for NLog and Microsoft's logging interface.

## How to Build
1. `cd into src/`
1. `dotnet build`

## How to Run
1. `cd into src/`
1. `dotnet run --project HelloWorld`

## How to Test
1. `cd into src/`
1. `dotnet test`

### Creating Other Projects in this Repository
1. `dotnet new mvc -n WebApplication`
1. `dotnet new console -n InstitutionConsole`

# Noteable Other Features/Packages
* Swagger (endpoint documentation) support for ASP.NET Core websites in a total of 5 lines: https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-2.2&tabs=visual-studio
* Dependency Injection built into all .NET Core applications (web and console. It was initially made for ASP.NET Core, so most internet documentation is for web apps, but the Nuget package can be referenced in a console): https://stackify.com/net-core-dependency-injection/ See the "Beyond the Web" section
* 

# Generally Useful Links
* .NET tutorials in general: https://docs.microsoft.com/en-us/dotnet/core/tutorials/index
* .NET architectural explanation: https://docs.microsoft.com/en-us/dotnet/standard/components
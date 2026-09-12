# SolutionWalker

## Introduction
Parses ("walks") solutions, projects, and references, storing the information in a database for easy querying.

Today, the application only parses Visual Studio solutions. It includes a command line interface (CLI) and prototype UI.

# Why
For decades I've frequently wanted to answer questions about large code bases such as

*   What projects reference other projects?
*   What projects use this NuGet package?

Within a single solution, Visual Studio can give you some answers. But if your code spans solutions or has huge numbers of projects, SolutionWalker can help.

I wrote the version version of SolutionWalker around 2004. It was an engineer's tool just for me. Then I rewrote it, but it was still just for me. This version will, I hope, be useful for others.

## Limitations
The best way right now to use the tool is to download the source code and run either the CLI or UI to import a folder of solution(s) into the database. You can also use the compiled versions of the tool, but there might be limits to query tools.

The very best tool to use for querying is [LINQPad](https://www.linqpad.net/). With it, you can attach to the DbContext in `SolutionWalker.dll` and take advantage of the context's models for querying.

You can also use a tool such as VS Code to query the SQLite database directly.

While it's tempting to write a full query tool, that's really not a good fit for SolutionWalker. The goal has always been to walk solutions and get 

## Getting Started
TBD, instructions for running and querying.

## Environment

Install                          | Version    
---------------------------------|------------
.NET                             | 10
PowerShell                       | 7.x
Visual Studio                    | VS 2022

Sources:
*   [.NET](https://dotnet.microsoft.com/download/dotnet)
*   [PowerShell](https://docs.microsoft.com/en-us/powershell/scripting/install/installing-powershell-core-on-windows)
*   [Visual Studio](https://visualstudio.microsoft.com/downloads/)

## Getting Started
> Be sure to use the correct versions from above.

**Environment**  
1.  Install PowerShell 7.x
1.  Install .NET 10.

```powershell
$ErrorActionPreference = 'Stop'
# other installations
```

**Application** 
```powershell
# Clone source
$ErrorActionPreference = 'Stop'
$userRoot = $env:userprofile
cd "$userRoot/source/repos"
git clone https://github.com/bladewolf55/SolutionWalker.git
cd SolutionWalker
# Build app
./build.ps1
```

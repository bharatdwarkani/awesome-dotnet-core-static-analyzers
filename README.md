# awesome-dotnet-core-static-analyzers
Awesome collection of .NET Core Static Analyzers using the .NET Compiler Platform (Roslyn). A sample project along with Cake Script for Continuous integration is also included in this repository with some of Analyzers added through Nugget. 

These analyzers helps in checking common mistakes, usage problems and enforcing coding standards. Every analyzers have options to exclude certain rules from analyzers globally. You can also create your own analyers. Checkout this guide [**Writing a roslyn analyzer**](https://www.meziantou.net/writing-a-roslyn-analyzer.htm).

[**Microsoft Reference Documentation**](https://docs.microsoft.com/en-us/visualstudio/code-quality/roslyn-analyzers-overview?view=vs-2019)

[**FXCopAnalyzers**](https://www.nuget.org/packages/Microsoft.CodeAnalysis.FxCopAnalyzers)  - Microsoft recommended code quality rules and .NET API usage rules, including the most important FxCop rules, implemented as analyzers using the .NET Compiler Platform (Roslyn). 

[**StyleCopAnalyzers**](https://www.nuget.org/packages/StyleCop.Analyzers/)  - An implementation of StyleCop's rules using Roslyn analyzers and code fixes

[**Security Code Scan**](https://security-code-scan.github.io/)  -  Detects various security vulnerability patterns: SQL Injection, Cross-Site Scripting (XSS), Cross-Site Request Forgery (CSRF), XML eXternal Entity Injection (XXE), etc.

[**Roslynator**](https://github.com/JosefPihrt/Roslynator)  - A collection of 500+ analyzers, refactorings, and fixes for C#, powered by Roslyn.

[**AsyncFixer**](https://www.nuget.org/packages/AsyncFixer)  - AsyncFixer helps developers in finding and correcting common async/await *misuses* (i.e., anti-patterns). AsyncFixer has been tested with thousands of open-source C# apps and successfully handles many corner cases.

[**Meziantou.Analyzer**](https://github.com/meziantou/Meziantou.Analyzer)  -A Roslyn analyzer to enforce some good practices in C#.

[**SerilogAnalyzer**](https://github.com/Suchiman/SerilogAnalyzer)  - Roslyn-based analysis for code using the Serilog logging library. Checks for common mistakes and usage problems.

[**Microsoft.AspNetCore.Mvc.Api.Analyzers**](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Api.Analyzers)  - CSharp Analyzers for ASP.NET Core MVC.

[**SonarAnalyzer.CSharp**](https://www.nuget.org/packages/SonarAnalyzer.CSharp)  - Analyzers which spot bugs and code smells in your code. This package is best used together with SonarLint for Visual Studio (http://vs.sonarlint.org/) and/or the SonarQube platform (http://www.sonarqube.org/).

[**NSubstitute.Analyzers.CSharp**](https://www.nuget.org/packages/NSubstitute.Analyzers.CSharp)  - Provides diagnostic analyzers to warn about incorrect usage of NSubstitute in C#.

[**xunit.analyzers**](https://www.nuget.org/packages/xunit.analyzers)  - Code Analyzers for projects using xUnit.net that help find and fix frequent issues when writing tests.

[**Microsoft.CodeQuality.Analyzers**](https://www.nuget.org/packages/Microsoft.CodeQuality.Analyzers)  - Microsoft recommended code quality rules implemented as analyzers using the .NET Compiler Platform (Roslyn). 

[**Microsoft.CodeAnalysis.VersionCheckAnalyzer**](https://www.nuget.org/packages/Microsoft.CodeAnalysis.VersionCheckAnalyzer)  - Microsoft.CodeAnalysis Version Check Analyzer

[**roslyn-analyzers**](https://github.com/dotnet/roslyn-analyzers)  - Roslyn analyzers analyze your code for style, quality and maintainability, design and other issues. 

Visit my site [**Share Tech Links**](https://sharetechlinks.com/)  for curated list of tech related interesting blog links.

**Pull requests are welcome for including new items in this list.**


## Sample project present in this repository

In sample project some of the mentioned Analyzers are included using Nugget Package.  

- Clone this repository  
- Open sln file in Visual Studio 2019, open any controller file. Build the project and wait for few minutes. Some times analyzer output might not show just try 2 to 3 times rebuilding project and wait for few minutes. You can find Analyzers errors in Warning Tab. You can identify warnings are produced from which analzers by checking prefix.  
Example - SCS - Denotes warning from Securtity Code Scan  
SA - Style Cop Analyzer Warnings
RCS - Roslynator Analyzer Warnings
![VS Warnings](https://github.com/bharatdwarkani/awesome-dotnet-core-static-analyzers/blob/master/images/Visual-Studio-Output.png)  

- You can also enable/disable rules by manually editing Rule Set file - [**CodeAnalysis.ruleset**](https://github.com/bharatdwarkani/awesome-dotnet-core-static-analyzers/blob/master/CodeAnalysis.ruleset) or you can change severity of rule from UI it will be reflected in ruleset files. There are options to supress warnings in particular file, method or block of code also.

![Turning On or Off Rules](https://github.com/bharatdwarkani/awesome-dotnet-core-static-analyzers/blob/master/images/Turning-Rule-On-Off.png)  

- you can add new analyzers using Nugget Packages. Several analyzers are available just search in Nugget Explorer "Analyzers"
![Adding new Analyzers](https://github.com/bharatdwarkani/awesome-dotnet-core-static-analyzers/blob/master/images/AddingAnalyzers.png) 


### Cake Build Script  - [**Cake Script File**](https://github.com/bharatdwarkani/awesome-dotnet-core-static-analyzers/blob/master/build/build.cake)

Cake Script helps in integrating to Continous Integration process. You can run cake script in Jenkins process when a merge/pull request is given to dev/master branch and enforce code standards by checking count of warnings and restricting Merge Requests to merge if any code violations.

Sample project also include Cake Script file. You can use Cake Build and integrate in Continuous Integration. 

Cake script does the following things

- Build project
- Run static code analyzers. 
- Output the warnings and Analyzers report in output file. 

# Running Cake Script in your local windows machine

- Navigate to folder /build 
- Open Powershel in build folder location and type ./build
![Running Cake Script](https://github.com/bharatdwarkani/awesome-dotnet-core-static-analyzers/blob/master/images/Running-Cake-Script.PNG)  

- Script will run and results will be logged in txt file in output directory
![Completion](https://github.com/bharatdwarkani/awesome-dotnet-core-static-analyzers/blob/master/images/Cake-Completion.png)  
![Results Folder](https://github.com/bharatdwarkani/awesome-dotnet-core-static-analyzers/blob/master/images/Cake-Output.png)  

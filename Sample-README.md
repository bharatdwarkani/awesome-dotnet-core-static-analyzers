# Readme for Sample 

In sample project some of the mentioned Analyzers are included using Nugget Package.  

- Open sln file in Visual Studio 2019, open any controller file. Build the project and wait for few minutes. Some times analyzer output might not show just try 2 to 3 times rebuilding project and wait for few minutes. You can find Analyzers errors in Warning Tab. You can identify warnings are produced from which analzers by checking prefix.  
![VS Warnings](https://github.com/bharatdwarkani/awesome-dotnet-core-static-analyzers/blob/master/images/Visual-Studio-Output.png)  

- You can also enable/disable rules using Rule Set file - [**CodeAnalysis.ruleset**](https://github.com/bharatdwarkani/awesome-dotnet-core-static-analyzers/blob/master/CodeAnalysis.ruleset)

![Turn On or Off Rules](https://github.com/bharatdwarkani/awesome-dotnet-core-static-analyzers/blob/master/images/Turning-Rule-On-Off.png)  

- you can add new analyzers using Nugget Packages. Several analyzers are available
![Adding new Analyzers](https://github.com/bharatdwarkani/awesome-dotnet-core-static-analyzers/blob/master/images/AddingAnalyzers.png) 


### Cake Build Script  - [**Cake Script File**](https://github.com/bharatdwarkani/awesome-dotnet-core-static-analyzers/blob/master/build/build.cake)

Sample project also include Cake Script file. You can use Cake Build and integrate in Continuous Integration. 

Cake script does the following things

- Build project
- Run static code analyzers. 
- Output the warnings and Analyzers report in output file. 

# Running Cake Script in your local windows machine

- Naviage to folder /build 
- Open Powershel in build folder location and type ./build
![Running Cake Script](https://github.com/bharatdwarkani/awesome-dotnet-core-static-analyzers/blob/master/images/Running-Cake-Script.PNG)  

- Script will run and results will be logged in txt file in output directory
![Completion](https://github.com/bharatdwarkani/awesome-dotnet-core-static-analyzers/blob/master/images/Cake-Completion.png)  
![Results Folder](https://github.com/bharatdwarkani/awesome-dotnet-core-static-analyzers/blob/master/images/Cake-Output.png)  



 



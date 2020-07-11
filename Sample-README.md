# Readme for Sample 

In sample project some of the mentioned Analyzers are included using Nugget Package.  

Open sln file in Visual Studio 2019. Build the project and wait for few minutes. You can find Analyzers errors in Warning Tab. You can identify warnings are produced from which analzers by checking prefix.  
You can also enable/disable rules using Rule Set file - https://github.com/bharatdwarkani/awesome-dotnet-core-static-analyzers/blob/master/CodeAnalysis.ruleset


# Cake Build Script  - [Cake Script File] (https://github.com/bharatdwarkani/awesome-dotnet-core-static-analyzers/blob/master/build/build.cake)

Sample project also include Cake Script file. You can use Cake Build and integrate in Continuous Integration. 

Cake script does the following things

- Build project
- Run static code analyzers. 
- Output the warnings and Analyzers report in output file. 


# Running Cake Script in your local windows machine

- Naviage to folder /build  
- Open Powershel in build folder location and type ./build
- Script will run and results will be logged in txt file in output directory

 



#addin "Cake.FileHelpers"
using System.Text.RegularExpressions

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

var logFilename = "CodeAnalyzer.txt";
var applicationPath = @"/sample/AnalyzerSample";
var applicationSolutionPath = @"/sample/AnalyzerSample/AnalyzerSample.sln";


var projectFramework = "netcoreapp3.1";

var cireports = Argument("cireports","../cireports");
var SCSReportDir = cireports + "/securitycodescan";
var FXReportDir = cireports + "/fxcopviolation";
var StyleCopReportsDir = cireports + "/stylecopviolation";

var styleCopReport = StyleCopReportsDir + "/StyleCopViolations.txt";
var fxCopReport = FXReportDir + "/FXCopViolations.txt";
var securityCodeScanReport = SCSReportDir + "/SecurityCodeScanViolations.txt";

var buildStatus = true;

var errorlogFolder = cireports + "/errorlogs/";
var waringsFolder = cireports + "/warnings/";

 
var currentDirectory = MakeAbsolute(Directory("../"));
var currentDirectoryInfo = new DirectoryInfo(currentDirectory.FullPath);

var projDir =  currentDirectory + applicationPath;
var binDir = String.Concat(projDir,"bin" ) ;

var solutionFile = currentDirectory + applicationSolutionPath; 

var outputDir = Directory(binDir) + Directory(configuration);
var fxCopViolationCount = 0;
var styleCopViolationCount = 0;
var securityCodeScanWarningCount = 0;
var xUnitWarningCount = 0;

var securityCodeRegex = "warning SCS";
var fxCopRegex = "warning CA";
var styleCopRegex = "warning SA";
var nullableRegex = "warning CS";
var styleCopAnalyzersRegex = "warning SX";
var xUnitRegex = "warning xUnit";
var apiAnalyzerRegex = "warning API";
var asyncAnalyzerRegex = "warning AsyncFixer";
var cSharpAnalyzerRegex = "warning RS";
var mvcAnalyzerRegex = "warning MVC";
var entityFrameworkRegex = "warning EF";
var rosylnatorAnalyzerRegex = "warning RCS";

var framework = Argument("framework", projectFramework);

var buildSettings = new DotNetCoreBuildSettings
     {
         Framework = framework,
         Configuration = configuration,
         OutputDirectory = outputDir
     };

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
	var binDirectories = currentDirectoryInfo.GetDirectories("bin", SearchOption.AllDirectories);
    var objDirectories = currentDirectoryInfo.GetDirectories("obj", SearchOption.AllDirectories);
    
    foreach(var directory in binDirectories){
        CleanDirectories(directory.FullName);
    }
    
    foreach(var directory in objDirectories){
        CleanDirectories(directory.FullName);
    }
    if (DirectoryExists(outputDir))
        {
            DeleteDirectory(outputDir, recursive:true);
        }
});

Task("Restore")
    .Does(() => {
        DotNetCoreRestore(solutionFile);
    });
	
Task("DeleteLogFile")
	.Does(()=>{
		
		if(FileExists(errorlogFolder + logFilename)){
			DeleteFile(errorlogFolder + logFilename);
		}
		
		if(FileExists(waringsFolder + logFilename)){
			DeleteFile(waringsFolder + logFilename);
		}				
	});
	
 
Task("Build")   
    .IsDependentOn("Clean")
    .IsDependentOn("Restore")
    .Does(() => {	
	try { 	
  


	  MSBuild(solutionFile , settings => 
	   settings.SetConfiguration(configuration)
	   .WithProperty("DeployOnBuild","true")
       .AddFileLogger(new MSBuildFileLogger{LogFile = waringsFolder + logFilename, MSBuildFileLoggerOutput=MSBuildFileLoggerOutput.WarningsOnly})
	  );  
	   } 	
	catch(Exception ex) {        
		throw new Exception(String.Format("Please fix the project compilation failures"));  
	}
    }); 

Task("Get-Security-Scan-Reports")
 .Does(() =>
 { 
    var securityCodeScanWarning = FileReadText(waringsFolder + logFilename);    
	securityCodeScanWarningCount = Regex.Matches(securityCodeScanWarning, securityCodeRegex).Count;

	if (DirectoryExists(SCSReportDir))
    {
	 DeleteDirectory(SCSReportDir, recursive:true);
	}

    if(securityCodeScanWarningCount != 0)
    {        
       Information("There are {0} Security Code violations found", securityCodeScanWarningCount);
    }
	
	if (!DirectoryExists(SCSReportDir)) {
		CreateDirectory(SCSReportDir);
	}

	FileWriteText(securityCodeScanReport, "Security Violations Error(s) : " + securityCodeScanWarningCount);
});

Task("Get-Fx-cop-Reports")
 .Does(() =>
 { 
	if (DirectoryExists(FXReportDir))
    {
	 DeleteDirectory(FXReportDir, recursive:true);
	}	 

	var fxCopWarning = FileReadText(waringsFolder + logFilename);
	fxCopViolationCount = Regex.Matches(fxCopWarning, fxCopRegex).Count;
    fxCopViolationCount += Regex.Matches(fxCopWarning, apiAnalyzerRegex).Count;
	fxCopViolationCount += Regex.Matches(fxCopWarning, asyncAnalyzerRegex).Count;
	fxCopViolationCount += Regex.Matches(fxCopWarning, cSharpAnalyzerRegex).Count;
	fxCopViolationCount += Regex.Matches(fxCopWarning, mvcAnalyzerRegex).Count;
	fxCopViolationCount += Regex.Matches(fxCopWarning, entityFrameworkRegex).Count; 
    fxCopViolationCount += Regex.Matches(fxCopWarning, rosylnatorAnalyzerRegex).Count; 
	fxCopViolationCount += Regex.Matches(fxCopWarning, nullableRegex).Count; 

    if(fxCopViolationCount != 0)
    {        
       Information("There are {0} FXCop violations found", fxCopViolationCount);
    }
	
	if (!DirectoryExists(FXReportDir)) {
		CreateDirectory(FXReportDir);
	}
	
	FileWriteText(fxCopReport, "FXCop Error(s) : " + fxCopViolationCount);
});

Task("Get-StyleCop-Reports")
 .Does(() =>
 { 
	if (DirectoryExists(StyleCopReportsDir))
    {
	 DeleteDirectory(StyleCopReportsDir, recursive:true);
	}	

	var styleCopWarning = FileReadText(waringsFolder + logFilename);
	styleCopViolationCount += Regex.Matches(styleCopWarning, styleCopRegex).Count;
	styleCopViolationCount += Regex.Matches(styleCopWarning, styleCopAnalyzersRegex).Count;

    if(styleCopViolationCount != 0)
    {        
       Information("There are {0} StyleCop violations found", styleCopViolationCount);
    }
	
	if (!DirectoryExists(StyleCopReportsDir)) {
		CreateDirectory(StyleCopReportsDir);
	}

	FileWriteText(styleCopReport, "Style Cop Error(s) : " + styleCopViolationCount);
});



Task("codeviolation")
    .IsDependentOn("Get-StyleCop-Reports")
	.IsDependentOn("Get-Fx-cop-Reports")
	.IsDependentOn("Get-Security-Scan-Reports")
    .Does(() =>
{
});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Build")
    .IsDependentOn("Codeviolation");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
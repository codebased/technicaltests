REM ** Be sure to install these nugets:
REM ** NUnit.ConsoleRunner
REM ** OpenCover
REM ** ReportGenerator
REM **
REM ** All paths should be entered without quotes

REM ** SET TestResultsFileProjectName=CalculatorResults
SET TestResultsFileProjectName=EqualExperts.ShoppingCart.UnitTests

REM ** SET DLLToTestRelativePath=Calculator\bin\Debug\MyCalc.dll
SET DLLToTestRelativePath=EqualExperts.ShoppingCart.UnitTests\bin\debug\EqualExperts.ShoppingCart.UnitTests.dll

REM ** Filters Wiki https://github.com/opencover/opencover/wiki/Usage
@ECHO OFF

REM ** SET Filters=+[Calculator]* -[Calculator]CalculatorTests.*
SET Filters=+[EqualExperts.ShoppingCart]* -[EqualExperts.ShoppingCart.UnitTests]* -[EqualExperts.ShoppingCart]*.Mock*

SET OpenCoverFolderName=OpenCover.4.6.519
SET NUnitConsoleRunnerFolderName=NUnit.ConsoleRunner.3.9.0
SET ReportGeneratorFolderName=ReportGenerator.3.1.2
SET MSBUILD="C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\msbuild.exe"
REM *****************************************************************

REM Create a 'GeneratedReports' folder if it does not exist
if not exist "%~dp0GeneratedReports" mkdir "%~dp0GeneratedReports"
if not exist "%~dp0GeneratedReportsHistory" mkdir "%~dp0GeneratedReportsHistory"


REM Remove any previous test execution files to prevent issues overwriting
IF EXIST "%~dp0%TestResultsFileProjectName%.trx" del "%~dp0%TestResultsFileProjectName%.trx%"

REM Remove any previously created test output directories
CD %~dp0
FOR /D /R %%X IN (%USERNAME%*) DO RD /S /Q "%%X"
 
call :NugetRestore
if %errorlevel% equ 0 (
    call :Build
)

if %errorlevel% equ 0 (
REM Run the tests against the targeted output
call :RunOpenCoverUnitTestMetrics
)

REM Generate the report output based on the test results
if %errorlevel% equ 0 (
 call :RunReportGeneratorOutput
)

REM Launch the report
if %errorlevel% equ 0 (
 call :RunLaunchReport
)
exit /b %errorlevel%

:NugetRestore 
"%~dp0nuget.exe" restore "%~dp0EqualExperts.ShoppingCart.sln"
exit /b %errorlevel%

:Build 
%MSBUILD%  "%~dp0EqualExperts.ShoppingCart.sln"  /p:TargetFrameworkVersion=v4.6
exit /b %errorlevel%

:RunOpenCoverUnitTestMetrics
"%~dp0packages\%OpenCoverFolderName%\tools\OpenCover.Console.exe" ^
-register:user ^
-target:"%~dp0packages\%NUnitConsoleRunnerFolderName%\tools\nunit3-console.exe" ^
-targetargs:"--noheader \"%~dp0%DLLToTestRelativePath%\"" ^
-filter:"%Filters%" ^
-mergebyhash ^
-skipautoprops ^
-excludebyattribute:"System.CodeDom.Compiler.GeneratedCodeAttribute" ^
-output:"%~dp0GeneratedReports\%TestResultsFileProjectName%.xml"
exit /b %errorlevel%

:RunReportGeneratorOutput
"%~dp0packages\%ReportGeneratorFolderName%\tools\ReportGenerator.exe" ^
-reports:"%~dp0GeneratedReports\%TestResultsFileProjectName%.xml" ^
-historydir:"%~dp0GeneratedReportsHistory%" ^
-targetdir:"%~dp0GeneratedReports\ReportGenerator Output" ^
-reporttypes:"html;Latex;HtmlSummary;HtmlChart;PngChart" ^
-tag:"step3"
exit /b %errorlevel%

:RunLaunchReport
start "report" "%~dp0GeneratedReports\ReportGenerator Output\index.htm"
exit /b %errorlevel%

@echo ons
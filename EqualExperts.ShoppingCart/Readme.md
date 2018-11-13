# Equal Experts Interview - Shopping Cart 

Welcome to the world of Shopping Cart. This test is written as a reply to an instruction given for version **741e2021841b2ee9dfe6da974bbeb934b579947f** file.

Please get a cup of coffee and review the attached files! :)

## Prerequisite

- [ ] .Net Framework - Version 4.6
- [ ] MSBuild.exe present at  `C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\msbuild.exe`
  - [ ] PS: If you decide to use an another version or a location of MSBuild.exe, please modify BuildAndTest.bat file accordingly

## Test Requirement CheckList

- [x] Test Coverage: Applied TDD approach using NUnit 3x, NSubstitude (Mock), and Shouldly (Assert) library
- [x] Build file: Hit **BuildAndTest.bat** file; uses MSBuild (.Net Framework 4x), NUnit for test run, OpenCover for code coverage xml report, ReportGenerator for transforming XML to HTML.
- [x] Simplicity: SOLID principle has been applied where possible, limited number of solution files; 
  - [ ] TODO: DTOs can be a separate project (standard 2.0?)for package distribution.
  - [ ] TODO: Repository can be a separate project.
- [x] Self-Explanatory: Indeed it is!
- [x] Version Control: 
  - [x] Local Git
  - [x] Steps 1,2,3 Tagged
  
## Build

> In order to run this project, you must go through the above prerequisite check list.

Click on BuildAndTest.bat and on success, it should open a code coverage page result from OpenCover.

> You must check for the right MSBuild version for .Net Framework 4.6. If you have any troubles with the batch file then I suggest you top open the solution file in Visual Studio and compile. After the successful compilation, you should be able to run this batch file. 



`Thank you`
@echo off

if "%1" == ""	goto USAGE1   
set library="%1"

if "%2" == ""	goto USAGE2
set out="%2"

set assembly="%3"
if "%3" == ""	set assembly="*"

set type="%4"
if "%4" == ""	set type="*"

set NUNIT_CONSOLE_PATH=C:\Users\dimitrijemitic1996\source\repos\RES\RES_SHES_PR-22-27-2015\Code coverage\NUnit-2.6.4\NUnit-2.6.4\bin\nunit-console.exe
set OPEN_COVER_RUNNER=C:\Users\dimitrijemitic1996\source\repos\RES\RES_SHES_PR-22-27-2015\Code coverage\opencover.4.6.519\OpenCover.Console.exe
set REPORT_GENERATOR=C:\Users\dimitrijemitic1996\source\repos\RES\RES_SHES_PR-22-27-2015\Code coverage\ReportGenerator_2.5.1.0\ReportGenerator.exe
set report_dir=SHES_REPORT

mkdir %out%\%report_dir%

%REPORT_GENERATOR% "-reports:C:\Users\dimitrijemitic1996\source\repos\RES\RES_SHES_PR-22-27-2015\RES_SHES_PR-22-27-2015\SHES_CODE_COVERAGE.xml" "-targetdir:%out%\%report_dir%\HTML" -reporttypes:Html;HtmlSummary

goto END

:USAGE1
echo "Parammeter #1 library path not set"
goto HELP

:USAGE2
echo "Parammeter #2 report path not set"

goto HELP

:HELP
echo 	Example: My_OpenCover_ReportGenerator.bat F:\NB\3.4.0\CheckoutUnitTesting\UI\Test\UnitTest\WorkManagementTestSuite\bin\x64\Release\TelventDMS.UI.UnitTest.WorkManagementTestSuite.dll F:\NB\3.4.0\CheckoutUnitTesting\UI\Test\UnitTest\WorkManagementTestSuite\report TelventDMS.UI.Components.WorkManagement* *

:END


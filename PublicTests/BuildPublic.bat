@echo off

rem SET THE PATH
@set PATH=%DevEnvDir%;%MSVCDir%\BIN;%VCINSTALLDIR%\Common7\Tools;%VCINSTALLDIR%\Common7\Tools\bin\prerelease;%VCINSTALLDIR%\Common7\Tools\bin;%FrameworkSDKDir%\bin;%FrameworkDir%\%FrameworkVersion%;%PATH%;

rem BUILD PUBLIC PROJECTS

echo VB.NET BUILDS --------------------------------------

echo Appearances
start /w devenv.exe /rebuild "Debug" C:\projects\Production\Schedule.NET\PublicTests\VB_Projects\Appearances\Appearances.sln
echo Datasets
start /w devenv.exe /rebuild "Debug" C:\projects\Production\Schedule.NET\PublicTests\VB_Projects\Datasets\Datasets.sln
echo DataViews
start /w devenv.exe /rebuild "Debug" C:\projects\Production\Schedule.NET\PublicTests\VB_Projects\DataViews\DataViews.sln
echo Dialogs
start /w devenv.exe /rebuild "Debug" C:\projects\Production\Schedule.NET\PublicTests\VB_Projects\Dialogs\Dialogs.sln
echo DoctorOffice API
start /w devenv.exe /rebuild "Debug" C:\projects\Production\Schedule.NET\PublicTests\VB_Projects\DoctorOfficeAPI\DoctorOfficeAPI.sln
echo DoctorOffice
start /w devenv.exe /rebuild "Debug" C:\projects\Production\Schedule.NET\PublicTests\VB_Projects\DoctorOffice\DoctorOffice.sln
echo Effects
start /w devenv.exe /rebuild "Debug" C:\projects\Production\Schedule.NET\PublicTests\VB_Projects\Effects\Effects.sln
echo MSAccess
start /w devenv.exe /rebuild "Debug" C:\projects\Production\Schedule.NET\PublicTests\VB_Projects\MSAccess\MSAccess.sln
echo MultiTest
start /w devenv.exe /rebuild "Debug" C:\projects\Production\Schedule.NET\PublicTests\VB_Projects\MultiTest\MultiTest.sln
echo Outlook
start /w devenv.exe /rebuild "Debug" C:\projects\Production\Schedule.NET\PublicTests\VB_Projects\OutlookExample\OutlookExample.sln
echo PropertyGrid
start /w devenv.exe /rebuild "Debug" C:\projects\Production\Schedule.NET\PublicTests\VB_Projects\PropertyGrid\PropertyGrid.sln
echo WeekSummary
start /w devenv.exe /rebuild "Debug" C:\projects\Production\Schedule.NET\PublicTests\VB_Projects\WeekSummary\WeekSummary.sln


echo C#.NET BUILDS --------------------------------------

echo Appearances
start /w devenv.exe /rebuild "Debug" C:\projects\Production\Schedule.NET\PublicTests\C#_Projects\Appearances\Appearances.sln
echo Datasets
start /w devenv.exe /rebuild "Debug" C:\projects\Production\Schedule.NET\PublicTests\C#_Projects\Datasets\Datasets.sln
echo DataViews
start /w devenv.exe /rebuild "Debug" C:\projects\Production\Schedule.NET\PublicTests\C#_Projects\DataViews\DataViews.sln
echo Dialogs
start /w devenv.exe /rebuild "Debug" C:\projects\Production\Schedule.NET\PublicTests\C#_Projects\Dialogs\Dialogs.sln
rem echo DoctorOffice API
rem start /w devenv.exe /rebuild "Debug" C:\projects\Production\Schedule.NET\PublicTests\C#_Projects\DoctorOfficeAPI\DoctorOfficeAPI.sln
rem echo DoctorOffice
rem start /w devenv.exe /rebuild "Debug" C:\projects\Production\Schedule.NET\PublicTests\C#_Projects\DoctorOffice\DoctorOffice.sln
echo Effects
start /w devenv.exe /rebuild "Debug" C:\projects\Production\Schedule.NET\PublicTests\C#_Projects\Effects\Effects.sln
echo MSAccess
start /w devenv.exe /rebuild "Debug" C:\projects\Production\Schedule.NET\PublicTests\C#_Projects\MSAccess\MSAccess.sln
echo MultiTest
start /w devenv.exe /rebuild "Debug" C:\projects\Production\Schedule.NET\PublicTests\C#_Projects\MultiTest\MultiTest.sln
echo Outlook
start /w devenv.exe /rebuild "Debug" C:\projects\Production\Schedule.NET\PublicTests\C#_Projects\OutlookExample\OutlookExample.sln
echo PropertyGrid
start /w devenv.exe /rebuild "Debug" C:\projects\Production\Schedule.NET\PublicTests\C#_Projects\PropertyGrid\PropertyGrid.sln
echo WeekSummary
start /w devenv.exe /rebuild "Debug" C:\projects\Production\Schedule.NET\PublicTests\C#_Projects\WeekSummary\WeekSummary.sln


echo -----------------------------------------------------
echo COMPLETE...
rem pause

exit
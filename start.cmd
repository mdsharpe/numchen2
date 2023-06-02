@echo off
wt ^
-d "%~dp0\src\Numchen.Client" pwsh -NoExit -Command dotnet watch run

exit

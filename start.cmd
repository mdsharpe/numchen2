@echo off
wt ^
-d "%~dp0\src\Numchen.Client" pwsh -NoExit -Command dotnet watch run --no-hot-reload; ^
new-tab -d "%~dp0\src\Numchen.Server" pwsh -NoExit -Command dotnet watch run

exit

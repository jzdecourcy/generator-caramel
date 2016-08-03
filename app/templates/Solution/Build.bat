set config=%1
set targets=%2

if "%config%" == "" (
   set config=Release
)

if "%targets%" == "" (
   set targets=Rebuild
)

%WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe <%= applicationName %>.sln /p:Configuration="%config%" /t:%targets%

pause

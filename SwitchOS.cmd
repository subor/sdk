@ECHO OFF
REM Please run this batch file as Administartor permission

set OSGUID=NULL

bcdedit.exe /enum {default} /v | find.exe /i "RUYIOS"
if /i "%errorlevel%" neq "0" goto :RUYIOS

bcdedit.exe /enum {default} /v | find.exe /i "WINOS"
if /i "%errorlevel%" neq "0" goto :WINOS

goto :ERROR

:RUYIOS
FOR /F "eol= tokens=2* delims= " %%i in ('bcdedit.exe /enum osloader /v ^| find /i "}"') do (
call :Check %%i RUYIOS
)
ECHO RUYIOS = %OSGUID%
GOTO :Switch

:WINOS
FOR /F "eol= tokens=2* delims= " %%i in ('bcdedit.exe /enum osloader /v ^| find /i "}"') do (
call :Check %%i WINOS
)
ECHO WINOS = %OSGUID%
GOTO :Switch

:Check
bcdedit /enum %1 /v | find /i "%2" >nul
if /i "%errorlevel%" equ "0" set OSGUID=%1
GOTO :EOF

:Switch
if /i "%OSGUID%" equ "NULL" goto :ERROR
bcdedit.exe /set {bootmgr} default %OSGUID%
bcdedit.exe /set {bootmgr} displayorder %OSGUID%
bcdedit.exe /set {bootmgr} timeout 0
bcdedit.exe /set {fwbootmgr} timeout 0
ECHO Success!!! Please restart your device to switch into another OS...
timeout.exe 6
GOTO :END

:ERROR
ECHO ERROR!!! Could not find any tag string in BCD, maybe caused by without Administartor permission.
pause

:END
exit /b 0
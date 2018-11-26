echo on

set ProjectDir=%1
set OutDir=%2
set Platform=%3

if "%OutDir%" == "" goto bad_args
if "%ProjectDir%" == "" goto bad_args
if "%Platform%" == "" goto bad_args
goto ok
:bad_args
echo Expect 3 arguments: $(ProjectDir) $(OutDir) $(Platform)
exit /B 1
:ok

mkdir %OutDir%\include
copy %ProjectDir%\RuyiSDK.h %OutDir%\include\RuyiSDK.h /y
xcopy %ProjectDir%\PubSub %OutDir%\include\PubSub /Y /I /E /R /F /D  /EXCLUDE:excludes.txt
xcopy %ProjectDir%\Generated %OutDir%\include\Generated /Y /I /E /R  /F /D /EXCLUDE:excludes.txt
xcopy %ProjectDir%\..\..\externals\thrift.cpp\src\thrift\*.h %OutDir%\include\thrift /Y /I /E /R /F /D
xcopy %ProjectDir%\..\..\externals\thrift.cpp\src\thrift\*.tcc %OutDir%\include\thrift /Y /I /E /R /F /D

xcopy %ProjectDir%\..\..\externals\ZeroMQ\lib\%Platform% %OutDir%\lib\zmq /Y /I /E /R /F /D

copy %ProjectDir%\RuyiString.h %OutDir%\include\RuyiString.h /y
xcopy %ProjectDir%\RuyiNet %OutDir%\include\RuyiNet /Y /I /E /R /F /D  /EXCLUDE:excludes.txt

xcopy %ProjectDir%\..\..\externals\boost_1_64_0\boost %OutDir%\include\boost /Y /I /E /R /F /D /EXCLUDE:excludes.txt
xcopy %ProjectDir%\..\..\externals\boost_1_64_0\lib\x64 %OutDir%\lib\boost /Y /I /E /R /F /D 


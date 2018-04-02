REM setup tool path
REM set RUNTIME_TOOL="../../../../tool_runtime"
if "%RUNTIME_TOOL%" == "" set "RUNTIME_TOOL=../../../../tool_runtime"
echo %RUNTIME_TOOL%
set PATH=%PATH%;%RUNTIME_TOOL%
echo %PATH%

REM clean temp folder
del tempgen /S /Q
mkdir tempgen


REM setup working folders
set DESC_FOLDER="../ServiceGenerated/SDKDesc"
set TEMP_FOLDER="tempgen"
set GENERATED_FOLDER="Generated"


REM setup SDK Desc converter 
set LocalizationLanguage="en"
set OutputType="thrift"



set FILE_NAME="SDKValidator"
mkdir %TEMP_FOLDER%/%FILE_NAME%
mkdir %GENERATED_FOLDER%/%FILE_NAME%
SDKDescToolConsole.exe %OutputType% %TEMP_FOLDER%/%FILE_NAME% %LocalizationLanguage% %DESC_FOLDER%/%FILE_NAME%.json %FILE_NAME%
thrift -gen cpp -r -out %GENERATED_FOLDER%/%FILE_NAME% %TEMP_FOLDER%/%FILE_NAME%/%FILE_NAME%SDKServices.thrift


set FILE_NAME="InputManager"
mkdir %TEMP_FOLDER%/%FILE_NAME%
mkdir %GENERATED_FOLDER%/%FILE_NAME%
SDKDescToolConsole.exe %OutputType% %TEMP_FOLDER%/%FILE_NAME% %LocalizationLanguage% %DESC_FOLDER%/%FILE_NAME%.json %FILE_NAME%
thrift -gen cpp -r -out %GENERATED_FOLDER%/%FILE_NAME% %TEMP_FOLDER%/%FILE_NAME%/%FILE_NAME%SDKServices.thrift

set FILE_NAME="StorageLayer"
mkdir %TEMP_FOLDER%/%FILE_NAME%
mkdir %GENERATED_FOLDER%/%FILE_NAME%
SDKDescToolConsole.exe %OutputType% %TEMP_FOLDER%/%FILE_NAME% %LocalizationLanguage% %DESC_FOLDER%/%FILE_NAME%.json %FILE_NAME%
thrift -gen cpp -r -out %GENERATED_FOLDER%/%FILE_NAME% %TEMP_FOLDER%/%FILE_NAME%/%FILE_NAME%SDKServices.thrift


set FILE_NAME="SettingSystem"
mkdir %TEMP_FOLDER%/%FILE_NAME%
mkdir %GENERATED_FOLDER%/%FILE_NAME%
SDKDescToolConsole.exe %OutputType% %TEMP_FOLDER%/%FILE_NAME% %LocalizationLanguage% %DESC_FOLDER%/%FILE_NAME%.json %FILE_NAME%
thrift -gen cpp -r -out %GENERATED_FOLDER%/%FILE_NAME% %TEMP_FOLDER%/%FILE_NAME%/%FILE_NAME%SDKServices.thrift

set FILE_NAME="GlobalInputDefine"
mkdir %TEMP_FOLDER%/%FILE_NAME%
mkdir %GENERATED_FOLDER%/%FILE_NAME%
SDKDescToolConsole.exe %OutputType% %TEMP_FOLDER%/%FILE_NAME% %LocalizationLanguage% %DESC_FOLDER%/%FILE_NAME%.json %FILE_NAME%
thrift -gen cpp -r -out %GENERATED_FOLDER%/%FILE_NAME% %TEMP_FOLDER%/%FILE_NAME%/%FILE_NAME%SDKServices.thrift

set FILE_NAME="BrainCloudService"
mkdir %TEMP_FOLDER%/%FILE_NAME%
mkdir %GENERATED_FOLDER%/%FILE_NAME%
SDKDescToolConsole.exe %OutputType% %TEMP_FOLDER%/%FILE_NAME% %LocalizationLanguage% %DESC_FOLDER%/%FILE_NAME%.json %FILE_NAME%
thrift -gen cpp -r -out %GENERATED_FOLDER%/%FILE_NAME% %TEMP_FOLDER%/%FILE_NAME%/%FILE_NAME%SDKServices.thrift

set FILE_NAME="Constants"
mkdir %TEMP_FOLDER%/%FILE_NAME%
mkdir %GENERATED_FOLDER%/%FILE_NAME%
SDKDescToolConsole.exe %OutputType% %TEMP_FOLDER%/%FILE_NAME% %LocalizationLanguage% %DESC_FOLDER%/%FILE_NAME%.json %FILE_NAME%
thrift -gen cpp -r -out %GENERATED_FOLDER%/%FILE_NAME% %TEMP_FOLDER%/%FILE_NAME%/%FILE_NAME%SDKServices.thrift

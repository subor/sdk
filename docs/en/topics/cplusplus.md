# C++ SDK Integration

This documentation is about how to intergrate Ruyi C++ SDK to a common VS C++ project.

## Prerequisites

- [Visual Studio 2017](https://www.visualstudio.com/vs/community/) version 15.3 or later with the following individual components:
    - Windows 10 SDK (10.0.15063.0) (under __SDKs, libraries, and frameworks__)

## Download SDK from developer website Instructions

1. You can directly download our sdk from our developer website(http://dev.playruyi.com). Our SDK files will be in two folders: __include__ and __lib__.  
Put them in one of your source folder.  For example, create a "RuyiSDK" folder, then put them under it.

1. Right click your solution, click "Properties"

1. In Configuration Selection, choose "Release" "x64"

1. Choose "Configuration Properties / C/C++ / General" in Property Page, add `$(ProjectDir)..\RuyiSDK\include` in "Additional Include Directories"

1. Choose "Configuration Properties / Linker / General" in Property Page, add `$(ProjectDir)..\RuyiSDK\lib`, `$(ProjectDir)..\RuyiSDK\lib\boost`, and `$(ProjectDir)..\RuyiSDK\lib\zmq` to "Additional Library Directiories"

1. Choose "Configuration Properties / Linker / Input" in Property page, add `RuyiSDK.lib` and `libzmq.lib` to "Additional Dependencies"

1. And `#include "RuyiSDK.h"` to your code and initialize the SDK:
    ```
    Ruyi::RuyiSDK* ruyiSDK = Ruyi::RuyiSDK::CreateSDKInstance(Ruyi::RuyiSDKContext Ruyi::RuyiSDKContext::Endpoint::Console, "localhost"));

    if (nullptr != ruyiSDK)
    {
        std::string ret;
        
        ruyiSDK->BCService->Authentication_ClearSavedProfileID(0);
        ruyiSDK->BCService->Authentication_AuthenticateEmailPassword(ret, "username", "password", true, 0);

        std::cout << ret << std::endl;
    }
    ```
1. Compile the code, if everything goes well, which means you've intergrate Ruyi SDK successfully.
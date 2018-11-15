# C++ SDK Integration

This documentation is about how to intergrate C++ SDK to a common VS C++ project.

## Prerequisites

- [Visual Studio 2017](https://www.visualstudio.com/vs/community/) version 15.3 or later with the following individual components:
    - Windows 10 SDK (10.0.15063.0) (under __SDKs, libraries, and frameworks__)

## Download

1. Download C++ SDK from [here](https://github.com/subor/sdk/releases). `RuyiSDKCpp/` contains two folders: __include__ and __lib__.  
Put them in one of your source folder.  For example, create a "RuyiSDK" folder, then put them under it.

1. Right click your solution, click __Properties__

1. In __Configuration Selection__, choose "Release" "x64"

1. Choose __Configuration Properties / C/C++ / General__ in Property Page, in __Additional Include Directories__ add `$(ProjectDir)..\RuyiSDK\include` 

1. Choose __Configuration Properties / Linker / General__ in Property Page, in __Additional Library Directiories__ add `$(ProjectDir)..\RuyiSDK\lib`, `$(ProjectDir)..\RuyiSDK\lib\boost`, and `$(ProjectDir)..\RuyiSDK\lib\zmq`

1. Choose __Configuration Properties / Linker / Input__ in Property page, to __Additional Dependencies__ add `RuyiSDK.lib` and `libzmq.lib`

1. And `#include "RuyiSDK.h"` to your code and initialize the SDK:

        Ruyi::RuyiSDK* ruyiSDK = Ruyi::RuyiSDK::CreateSDKInstance(Ruyi::RuyiSDKContext Ruyi::RuyiSDKContext::Endpoint::Console, "localhost"));

        if (nullptr != ruyiSDK)
        {
            std::string ret;
            
            ruyiSDK->BCService->Authentication_ClearSavedProfileID(0);
            ruyiSDK->BCService->Authentication_AuthenticateEmailPassword(ret, "username", "password", true, 0);

            std::cout << ret << std::endl;
        }

1. Compile the code, if it succeeds you've successfully intergrated the SDK.
# 集成C++SDK

本文内容是关于如何将Ruyi C++SDK集成到一个通用的Visual Studio C++项目中。

## 前提条件

- [Visual Studio 2017](https://www.visualstudio.com/vs/community/)15.3或之后版本，包括以下组件:
    - Windows 10 SDK (10.0.15063.0) (包括相关__SDKs, 库和框架__)

## 从开发者网站下载SDK的接入说明

1. 从开发者网站(http://dev.playruyi.com/udownloadslist/SDK)下载SDK. 包括两个文件夹: __include__ 和 __lib__。  
把它们放在你的源代码文件夹下。比如，创建一个"RuyiSDK"文件夹， 把这两个文件夹放在该文件夹下。

1. 右击项目工程文件，选"属性(Properties)"

1. 在项目版本配置选项，选"Release" "x64"

1. 在属性页面选择"Configuration Properties / C/C++ / General"项,在"Additional Include Directories"处填`$(ProjectDir)..\RuyiSDK\include` 

1. 在属性页面选择"Configuration Properties / Linker / General"项,在"Additional Library Directiories"处填`$(ProjectDir)..\RuyiSDK\lib`,`$(ProjectDir)..\RuyiSDK\lib\boost`,`$(ProjectDir)..\RuyiSDK\lib\zmq`

1. 在属性页面选择"Configuration Properties / Linker / Input"项, 在"Additional Dependencies"处填`RuyiSDK.lib`和`libzmq.lib`

1. 添加`#include "RuyiSDK.h"`到对应的项目代码中，通过以下代码初始化SDK:

        Ruyi::RuyiSDK* ruyiSDK = Ruyi::RuyiSDK::CreateSDKInstance(Ruyi::RuyiSDKContext Ruyi::RuyiSDKContext::Endpoint::Console, "localhost"));

        if (nullptr != ruyiSDK)
        {
            std::string ret;
            
            ruyiSDK->BCService->Authentication_ClearSavedProfileID(0);
            ruyiSDK->BCService->Authentication_AuthenticateEmailPassword(ret, "username", "password", true, 0);

            std::cout << ret << std::endl;
        }

1. 编译项目，如果没有编译错误，说明RuyiSDK已集成成功。
# 编译SDK源码

[SDK二进制文件](https://dev.playruyi.com/udownloadslist/SDK)可以从开发者网站上获取。多数情况下对于开发者来说这已经足够了(也可以参考[Unity](unity.md)和[虚幻4](ue4.md)文档).

本文讨论自己编译SDK。这种做法在以下情况下可能有必要:  

* 使用我们不直接提供的[编程/脚本语言](https://thrift.apache.org/docs/Languages)
* 用到的库有使用特殊的工具链或者编译/链接符号

可以参考[这里](layer0.md)，客户端SDK使用[Apache Thrift](https://thrift.apache.org/)。Thrift接口定义，C++/C#Visual Studio项目以及RuyiSDK的源码都可以从[sdk_source仓库](https://bitbucket.org/playruyi/sdk_source)获取.

## C++

__前提条件__

* 参考[C++前提条件](cplusplus.md#prerequisites)
* [我们提供的](https://bitbucket.org/playruyi/sdk_source/downloads/externals.zip)第三方库，或者自己编译第三方库:
    * [thrift](https://thrift.apache.org/) 版本号0.10.0 [下载](http://archive.apache.org/dist/thrift/0.10.0/)   
        * [boost](http://www.boost.org/) 版本号 1.64.0 (thrift使用) [下载](https://sourceforge.net/projects/boost/files/boost-binaries/1.64.0/)
        * [openssl](https://www.openssl.org/) 版本号 1.1.1-dev (thrift使用)
    * [jsoncpp](https://github.com/open-source-parsers/jsoncpp) 版本号 1.8.3 (C++测试单元使用) [下载](https://github.com/open-source-parsers/jsoncpp/releases/tag/1.8.3)
    * [zeromq](http://zeromq.org/) 版本号 4.2

__说明__

1. 克隆或下载`bitbucket.org/playruyi/sdk_source.git`到 __sdk__ 文件夹:  
    `git clone https://your_username_here@bitbucket.org/playruyi/sdk_source.git sdk`
1. 解压第三方库([在之前的前提条件]中列出(#prerequisites))到 __externals/__ (和 __sdk/__ 同级)文件夹。如下所示:

        +---externals
        |   +---boost_1_64_0
        |   |   +---boost
        |   |   \---lib
        |   |       \---x64
        |   +---jsoncpp
        |   |   +---include
        |   |   |   \---json
        |   |   \---src
        |   |       \---lib_json
        |   +---OpenSSL
        |   |   +---include
        |   |   |   \---openssl
        |   |   \---lib
        |   |       \---engines-1_1
        |   +---thrift.cpp
        |   |   +---src
        |   |   |   \---thrift
        |   |   \---test
        |   +---thrift0.10.0
        |   \---ZeroMQ
        |       +---include
        |       \---lib
        \---sdk
            +---RuyiLogger
            +---RuyiSDK
            +---RuyiSDKCpp
            +...

1. 编译第三方库
    * 如果需要重定向项目，使用 __Windows SDK version__  10.0.15063.0， __Platform Toolset__ 为"Upgrade to v141"
    * 一般选 __Release__ 和 __x64__
1. 打开`sdk/SDK.sln`
    * __Release__ 编译使用`/MD`
    * __Release_mt__ 编译使用`/MT`
1. [编译SDK](#Building)

## C Sharp/C# #

__前提条件__

* [thrift](https://thrift.apache.org/) 版本号 0.10.0 [下载](http://archive.apache.org/dist/thrift/0.10.0/)
* [netmq](https://netmq.readthedocs.io/en/latest/) 版本号 4.0.0.1 (通过nuget下载)

__说明__

1. 打开`sdk/SDK.sln`
    * `.Net Framework 3.5`面向使用Unity 3D的项目
    * `.Net Standard`面向使用.Net Standard 2.0([详细](https://docs.microsoft.com/en-us/dotnet/standard/net-standard))的项目
1. [编译SDK](#Building)

## 编译

[layer0](layer0.md)运行时，查看客户端应用使用的SDK版本。编译的SDK版本需要和layer0版本相匹配。

1. 查看需要编译的SDK版本号：
    * 右击`Layer0/Layer0.exe`, 选择 __属性(Properties)__,__详细(Details)__页签，查看__文件版本(File version)__的值(形如`a.b.c.d` (e.g `0.7.2.1447`)).
1. 编译对应版本号的SDK:
    * 把`/p:AssemblyMain`和`/p:AssemblyRevision`(C++)和`/p:AssemblyVersion`(C#)项传入 __msbuild__:  

        `msbuild SDK.sln /p:AssemblyVersion=a.b.c.d /p:AssemblyMain=a.b.c /p:AssemblyRevision=d`

        比如`0.7.2.1447`:

        `msbuild SDK.sln /p:AssemblyVersion=0.7.2.1447 /p:AssemblyMain=0.7.2 /p:AssemblyRevision=1447`

## Thrift

SDK源码还包括[Thrift接口定义](https://bitbucket.org/playruyi/sdk_source/src/master/ThriftFiles/)。这意味着可以生成[不同语言版本的](https://thrift.apache.org/docs/Languages)RuyiSDK.

运行`thrift.exe --help`命令查找支持的语言。

可以使用[开发者工具](devtool.md)提供的API工具生成对应语言的API。

比如，生成SDK功能对应语言(C++,C#等)的API (参考[sdk源码](https://bitbucket.org/playruyi/sdk_source)):
```
:: C++
DevTools\RuyiShell.exe -v Debug ApiTool --ThriftFiles=sdk\ThriftFiles --ThriftExe=..\tools\thrift\thrift.exe --Gen=cpp --ServiceOutput=sdk\ServiceGenerated\Generated --Options=OutputPrefix --Generate

:: C#
DevTools\RuyiShell.exe -v Debug ApiTool --ThriftFiles=sdk\ThriftFiles --ThriftExe=..\tools\thrift\thrift.exe --Gen="csharp:async,union" --ServiceOutput=sdk\ServiceGenerated\Generated --CommonOutput=sdk\ServiceCommon\Generated --Generate
```

# Build SDK Source

[SDK binaries](https://github.com/subor/sdk/releases) should be sufficent for the majority of development scenarios (also check the [Unity](unity.md) and [UE4](ue4.md) docs).

This document discusses building the SDK yourself.  This may be necessary in the following situations:

* You use a [supported programming language](https://thrift.apache.org/docs/Languages) whose API we don't provide
* You need libraries built with a particular toolchain or compiler/linker flags

As discussed [here](layer0.md), the client SDK uses [Apache Thrift](https://thrift.apache.org/).  The Thrift interface definitions, C++/C# Visual Studio projects, and sourcecode for the Ruyi SDK are available from the [SDK source repository](https://github.com/subor/sdk/tree/master/ThriftFiles).

## C++

__Prerequisites__

* See [C++ prerequsites](cplusplus.md#prerequisites)
* External C++ libraries [provided by us](https://github.com/subor/sdk/releases), or built on your own:
    * [thrift](https://thrift.apache.org/) version 0.11 [Download](https://thrift.apache.org/download)
        * [boost](http://www.boost.org/) version 1.64.0 (used by thrift) [Download](https://sourceforge.net/projects/boost/files/boost-binaries/1.64.0/)
        * [openssl](https://www.openssl.org/) version 1.1.1-dev (used by thrift)
    * [jsoncpp](https://github.com/open-source-parsers/jsoncpp) version version 1.8.3 (used by cpp unit test) [Download](https://github.com/open-source-parsers/jsoncpp/releases/tag/1.8.3)
    * [zeromq](http://zeromq.org/) version 4.2

__Instructions__

1. Clone or download `https://github.com/subor/sdk.git` to __sdk__ folder:  
    `git clone https://your_username_here@github.com/subor/sdk.git sdk`
1. Unzip external libs (listed [above in prerequisites](#prerequisites)) to __externals/__ folder beside __sdk/__.  Like this:

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
        |   |   +---src
        |   |   |   \---thrift
        |   |   \---test
        |   +---thrift.csharp
        |   \---ZeroMQ
        |       +---include
        |       \---lib
        \---sdk
            +---RuyiLogger
            +---RuyiSDK
            +---RuyiSDKCpp
            +...

1. Build external libs
    * If asked to retarget projects, for __Windows SDK version__ pick 10.0.15063.0 and __Platform Toolset__ "Upgrade to v141"
    * Select __Release__ and __x64__ when possible
1. Open `sdk/SDK.sln`
    * __Release__ is for libraries compiled with `/MD`
    * __Release_mt__ is for libraries compiled with `/MT`
1. [Build the SDK](#building)

## C Sharp/C# #

__Prerequisites__

* [thrift](https://thrift.apache.org/) version 0.11 [Download](https://thrift.apache.org/download)
* [netmq](https://netmq.readthedocs.io/en/latest/) version 4.0.0.1 (via nuget)

__Instructions__

1. Open `sdk/SDK.sln`
    * `.Net Framework 3.5` contains projects suitable for Unity 3D
    * `.Net Standard` contains projects targetting .Net Standard 2.0 ([details](https://docs.microsoft.com/en-us/dotnet/standard/net-standard))
1. [Build the SDK](#building)

## Building

The runtime, [layer0](layer0.md), checks the version of the SDK used by client applications.  To satisfy this check the SDK should be compiled as the same version.

1. Get version to build SDK for
    * Right-click `Layer0/Layer0.exe`, select __Properties__ then __Details__ tab and note __File version__ value.  It should be similar to `a.b.c.d` (e.g `0.7.2.1447`).
1. Build the SDK for that version
    * Pass `/p:AssemblyMain` and `/p:AssemblyRevision` (for C++) and `/p:AssemblyVersion` (for C#) options to __msbuild__:  

        `msbuild SDK.sln /p:AssemblyVersion=a.b.c.d /p:AssemblyMain=a.b.c /p:AssemblyRevision=d`

        e.g. for `0.7.2.1447`:

        `msbuild SDK.sln /p:AssemblyVersion=0.7.2.1447 /p:AssemblyMain=0.7.2 /p:AssemblyRevision=1447`

## Thrift

The SDK source also includes the underlying [Thrift interface definitions](https://github.com/subor/sdk/tree/master/ThriftFiles).  This means the Ruyi SDK can be generated for a [large number of different langauges](https://thrift.apache.org/docs/Languages).

Run `thrift.exe --help` for a full list of supported languages (generators) and options.

The API Tool provided with [devtool](devtool.md) provdes some assistance working with our Thrift files.

For example, to generate API similar to what we provide in SDK (see [sdk source](https://github.com/subor/sdk)):
```
:: C++
DevTools\RuyiShell.exe -v Debug ApiTool --ThriftFiles=sdk\ThriftFiles --ThriftExe=..\tools\thrift\thrift.exe --Gen=cpp --ServiceOutput=sdk\ServiceGenerated\Generated --Options=OutputPrefix --Generate

:: C#
DevTools\RuyiShell.exe -v Debug ApiTool --ThriftFiles=sdk\ThriftFiles --ThriftExe=..\tools\thrift\thrift.exe --Gen="csharp:async,union" --ServiceOutput=sdk\ServiceGenerated\Generated --CommonOutput=sdk\ServiceCommon\Generated --Generate
```

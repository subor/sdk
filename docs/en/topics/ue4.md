# UE4 Integration

Details how we integrated Ruyi C++ SDK with [Unreal Engine 4](https://www.unrealengine.com/en-US/) for the [UE4 sample](https://bitbucket.org/playruyi/unreal_demo).

## Prerequisites

- [Visual Studio 2017](https://www.visualstudio.com/vs/community/) version 15.3 or later with the following individual components:
    - Windows 10 SDK (10.0.15063.0) (under __SDKs, libraries, and frameworks__)
- Unreal Engine 18, Compiled version

## Instructions

1. Our SDK files will be in two folders: __include__ and __lib__.  Put them in one of your game module source folder.  For example, `source/ModuleName/include` and `source/ModuleName/lib`.  They may be put in a sub-folder, just make sure they're in the same folder.
1. Open __ModuleName.Build.cs__ and add `ModuleName/xxx/include` to the `PublicIncludePaths` property.  For example:

        PublicIncludePaths.AddRange(
            new string[] {
                "ModuleName/include",
            }
        );

1. Add `using System.IO;` to the top of the file.  Bind lib path with:

        private string ModulePath
        {
            get { return ModuleDirectory; }
        }

        private string LibPath
        {
            get { return Path.GetFullPath(Path.Combine(ModulePath, "xxx/lib/")); }
        }

1. Add the following to the same function:

        PublicDelayLoadDLLs.Add(Path.Combine(LibPath, "zmq", "libzmq.dll"));

        PublicAdditionalLibraries.Add(Path.Combine(LibPath, "RuyiSDK.lib"));
        PublicAdditionalLibraries.Add(Path.Combine(LibPath, "zmq", "libzmq.lib"));

        PublicAdditionalLibraries.Add(Path.Combine(LibPath, "boost", "libboost_chrono-vc141-mt-1_64.lib"));
        PublicAdditionalLibraries.Add(Path.Combine(LibPath, "boost", "libboost_chrono-vc141-mt-gd-1_64.lib"));
        PublicAdditionalLibraries.Add(Path.Combine(LibPath, "boost", "libboost_date_time-vc141-mt-1_64.lib"));
        PublicAdditionalLibraries.Add(Path.Combine(LibPath, "boost", "libboost_date_time-vc141-mt-gd-1_64.lib"));
        PublicAdditionalLibraries.Add(Path.Combine(LibPath, "boost", "libboost_system-vc141-mt-1_64.lib"));
        PublicAdditionalLibraries.Add(Path.Combine(LibPath, "boost", "libboost_system-vc141-mt-gd-1_64.lib"));
        PublicAdditionalLibraries.Add(Path.Combine(LibPath, "boost", "libboost_thread-vc141-mt-1_64.lib"));
        PublicAdditionalLibraries.Add(Path.Combine(LibPath, "boost", "libboost_thread-vc141-mt-gd-1_64.lib"));

1. Copy `lib/zmq/libzmq.dll` to the build output folder.  For example, `Binaries/Win64`.
1. Open your project with Unreal Engine 4 Editor.  Click __File -> Refresh Visual Studio Project__ (or right-click __xxxxx.uproject__ file and click __Generate visual studio project file__).  Wait for it to finish, then reload your Visual Studio project and you will find __include__ and __lib__ folders in _Solution Explorer_ (click __View -> Solution Explorer__).
1. When using SDK functions, include `RuyiSDK.h` and use apprpropriate namespaces (like `Ruyi::RuyiSDK`).  Refer to the [UE4 sample](https://bitbucket.org/playruyi/unreal_demo) and [SDK documentation](http://dev.playruyi.com/api) for API details.
1. Build your project.

## Common Issues

- Since the sdk uses [boost](http://www.boost.org/), you may encounter `error LNK2038: mismatch detected for 'boost__type_index__abi': value 'RTTI is used'`.  You can solve this by adding `bUseRTTI = true;` to __xxxx.build.cs__.

- Similarly: `Error C4577: 'noexcept' used with no exception handling mode specified`.  You can solve this by adding `bEnableExceptions = true;` to __xxx.build.cs__.

# UE4 Source Code Integration

1 download the source code of SDK and externals from git

2 create a "include" folder and "lib" folder under your main module folder

3 copy "boost"(from RuyiSDKCpp\bin\Release\include) "thrift"(from RuyiSDKCpp\bin\Release\include) "Generated" "PubSub" "RuyiNet" (from RuyiSDKCpp)folder to your "include" file

4 copy "resource.h" "RuyiSDK.h" "RuyiSDK.cpp" "RuyiString.h" "version.info" (from sdk\RuyiSDKCpp)"zmq.h" "zmq.hpp" "zmq_addon.hpp" "zmq_utils.h"(from externals\ZeroMQ\include) files to your "include" file

5 copy "boost" folder (from "RuyiSDKCpp\bin\Release\lib") to "lib" folder.

6 copy "zmq" folder (from "RuyiSDKCpp\bin\Release\lib") to this "lib" folder

7 copy all files under "externals\thrift.cpp\Release" to "lib" folder

8 right click your project file and click "Generate visual studio files"

9 Add codes below
    private string ModulePath
    {
        get { return ModuleDirectory; }
    }

    private string LibPath
    {
        get { return Path.GetFullPath(Path.Combine(ModulePath, "lib/")); }
    } 

    public RuyiSDKDemo(ReadOnlyTargetRules Target) : base(Target)
	{
        bUseRTTI = true;
        bEnableExceptions = true;

        PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;

		PublicDependencyModuleNames.AddRange
            (
                new string[] 
                {
                    "Core",
                    "CoreUObject",
                    "Engine",
                    "InputCore",
                    "HeadMountedDisplay",
                    "Json",
                    "ImageWrapper",
                    "RHI",
                    "RenderCore",
                    "UMG",
                }
            );

        PublicIncludePaths.AddRange(
            new string[] {

                "RuyiSDKDemo/include",
                "RuyiSDKDemo/include/Generated/CommonType",
			}
            );

        PublicDelayLoadDLLs.Add(Path.Combine(LibPath, "zmq", "libzmq.dll"));

        PublicAdditionalLibraries.Add(Path.Combine(LibPath, "libthrift.lib"));

        //PublicAdditionalLibraries.Add(Path.Combine(LibPath, "RuyiSDK.lib"));
        PublicAdditionalLibraries.Add(Path.Combine(LibPath, "zmq", "libzmq.lib"));

        PublicAdditionalLibraries.Add(Path.Combine(LibPath, "boost", "libboost_chrono-vc141-mt-1_64.lib"));
        PublicAdditionalLibraries.Add(Path.Combine(LibPath, "boost", "libboost_chrono-vc141-mt-gd-1_64.lib"));
        PublicAdditionalLibraries.Add(Path.Combine(LibPath, "boost", "libboost_date_time-vc141-mt-1_64.lib"));
        PublicAdditionalLibraries.Add(Path.Combine(LibPath, "boost", "libboost_date_time-vc141-mt-gd-1_64.lib"));
        PublicAdditionalLibraries.Add(Path.Combine(LibPath, "boost", "libboost_system-vc141-mt-1_64.lib"));
        PublicAdditionalLibraries.Add(Path.Combine(LibPath, "boost", "libboost_system-vc141-mt-gd-1_64.lib"));
        PublicAdditionalLibraries.Add(Path.Combine(LibPath, "boost", "libboost_thread-vc141-mt-1_64.lib"));
        PublicAdditionalLibraries.Add(Path.Combine(LibPath, "boost", "libboost_thread-vc141-mt-gd-1_64.lib"));

        PrivateIncludePathModuleNames.AddRange(
            new string[] 
            {
                "DesktopPlatform",
            }
            );
    }
basicly, it's same as use binary version, just remove the sdk lib files

11 For any C++ base code, it's basic same theory. Include all the head files, add lib directory to your project.

# issues you may encouter when integrate source code

1 if you compile with error "\thrift\protocol\tbinaryprotocol.tcc(441): error C4706: assignment within conditional expression"

you can try to add the windows 10 sdk to the building directories. Or you can just change the code in "\thrift\protocol\tbinaryprotocol.tcc"

it's very simple.
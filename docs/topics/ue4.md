# UE4 Integration

Details how we integrated Ruyi C++ SDK with [Unreal Engine 4](https://www.unrealengine.com/en-US/) for the [UE4 demo](https://github.com/subor/sample_ue4_platformer).

Also see [packaging instructions](ue4_package.md).

## Prerequisites

- See [prerequisites for C++ SDK](cplusplus.md#Prerequsites)
- Unreal Engine 18 (4.18), Compiled version

## Using SDK Binary

1. Download the [latest SDK release](https://github.com/subor/sdk/releases/)
1. The C++ SDK contains two folders: __include__ and __lib__.  Copy them to your UE4 module source folder.  E.g.: `Source/ModuleName/include` and `Source/ModuleName/lib`.
1. Open `Source/ModuleName/ModuleName.Build.cs` and add `ModuleName/include` to the `PublicIncludePaths` property.  For example:

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

1. Copy `lib/zmq/libzmq.dll` to the build output folder.  E.g., `Binaries/Win64`.
1. Open your project with Unreal Engine 4 Editor.  Click __File -> Refresh Visual Studio Project__ (or right-click __xxxxx.uproject__ file and click __Generate visual studio project file__).  Wait for it to finish, then reload your Visual Studio project and you will find __include__ and __lib__ folders in _Solution Explorer_ (click __View -> Solution Explorer__).
1. When using SDK functions, include `RuyiSDK.h` and use apprpropriate namespaces (like `Ruyi::RuyiSDK`).  Refer to the [SDK documentation](https://subor.github.io/api/cpp/en-US/) for API details.
1. Build your project.

## Building SDK Binary

You can also use a binary built from the [SDK source](https://github.com/subor/sdk).

1. [Build SDK Binary](build_sdk_binary.md)

1. Go to "RuyiSDKCpp\bin\Release", copy the __include__ and __lib__ folder to your main module.

1. Follow remainder of instructions from ["Using SDK Binary"](#using-sdk-binary)

## Known Issues

- Since the SDK uses [boost](http://www.boost.org/), you may encounter `error LNK2038: mismatch detected for 'boost__type_index__abi': value 'RTTI is used'`.  You can solve this by adding `bUseRTTI = true;` to __xxxx.build.cs__.

- Similarly: `Error C4577: 'noexcept' used with no exception handling mode specified`.  You can solve this by adding `bEnableExceptions = true;` to __xxx.build.cs__.

- If you encounter:

        RuyiSDK.lib(RuyiNetService.obj) : error LNK2001: unresolved external symbol __std_reverse_trivially_swappable_1
        RuyiSDK.lib(RuyiNetVideoService.obj) : error LNK2001: unresolved external symbol __std_reverse_trivially_swappable_1
        RuyiSDK.lib(RuyiNetGamificationService.obj) : error LNK2001: unresolved external symbol __std_reverse_trivially_swappable_1
        D:\usr\sample_ue4_demo\Binaries\Win64\UE4Editor-RuyiSDKDemo.dll : fatal error LNK1120: 1 unresolved externals

This is caused by UE4 using __v140__ toolset while our C++ SDK binary was compiled with __v141__.
You can generate your VS project files on command line with `-2017` param:

    UnrealBuildTool.exe -projectfiles -project="C:/XXX.uproject" -game -engine -progress -2017

If it stills use v140 toolset:

1. Open Registry Editor by running `regedit`
1. Locate `HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\VisualStudio\SxS\VC7`
1. Normally there is "14.0" and "15.0" keys.  Delete "14.0".  And, if it doesn't exist already, create "15.0" with value data of the install path of Visual Studio 2017 (e.g. `C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\VC`).  
![](/docs/img/unreal_compile_02.png)
1. Re-generate the project files on command line (using `-2017` again)
1. Open the sln project file, compile it, it should work fine.
1. You can add the "14.0" key back after you generate the project files
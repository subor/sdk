# UE4 Integration

Details how we integrated Ruyi C++ SDK with [Unreal Engine 4](https://www.unrealengine.com/en-US/).

Also see [packaging instructions](ue4_package.md).

## Prerequisites

- See [prerequisites for C++ SDK](cplusplus.md#prerequisites)
- Unreal Engine 18 (4.18), Compiled version

## Using SDK Binary

Here we detail adding the precompiled SDK binary to the [UE4 demo](https://github.com/subor/sample_ue4_platformer).  The same process can be followed for other UE4 projects, substituting `PlatformerGame` with the name of your project.

1. Download the [latest SDK release](https://github.com/subor/sdk/releases/)
1. The C++ SDK contains two folders: __include/__ and __lib/__.  Copy them to your UE4 module source folder.  E.g.: `Source/PlatformerGame/RuyiSDK/include` and `Source/PlatformerGame/RuyiSDK/lib`.
1. Open `Source/PlatformerGame/PlatformerGame.Build.cs`
1. Add `using System.IO;` to the top of the file.  Bind lib path with:

        private string ModulePath
        {
            get { return ModuleDirectory; }
        }

        private string LibPath
        {
            get { return Path.GetFullPath(Path.Combine(ModulePath, "RuyiSDK/lib/")); }
        }


1. Inside the constructor `public PlatformerGame(ReadOnlyTargetRules Target)` add SDK paths to the `PublicIncludePaths` property:

        PublicIncludePaths.AddRange(
            new string[] {
                "PlatformerGame/RuyiSDK/include",
                "PlatformerGame/RuyiSDK/include/Generated/CommonType",
            });

1. Enable __RTTI__ and __exceptions__ for boost:

        bUseRTTI = true;
        bEnableExceptions = true;
        Definitions.Add("BOOST_ALL_DYN_LINK");

1. Specify libraries:

        PublicAdditionalLibraries.Add(Path.Combine(LibPath, "RuyiSDK.lib"));
		PublicAdditionalLibraries.Add(Path.Combine(LibPath, "zmq", "libzmq.lib"));
		PublicAdditionalLibraries.Add(Path.Combine(LibPath, "boost", "boost_chrono-vc141-mt-1_64.lib"));
		PublicAdditionalLibraries.Add(Path.Combine(LibPath, "boost", "boost_date_time-vc141-mt-1_64.lib"));
		PublicAdditionalLibraries.Add(Path.Combine(LibPath, "boost", "boost_system-vc141-mt-1_64.lib"));
		PublicAdditionalLibraries.Add(Path.Combine(LibPath, "boost", "boost_thread-vc141-mt-1_64.lib"));


1. Copy runtime libraries `lib/zmq/libzmq.dll` and `lib/boost/*.dll` to the build output folder: `Binaries/Win64`.
1. Open your project with Unreal Engine 4 Editor.  Click __File -> Refresh Visual Studio Project__ (or right-click __PlatformerGame.uproject__ file and click __Generate visual studio project file__).  Wait for it to finish, then reload your Visual Studio project and you will find __include__ and __lib__ folders in _Solution Explorer_ (click __View -> Solution Explorer__).
1. When using SDK functions, include `RuyiSDK.h` and use apprpropriate namespaces (like `Ruyi::RuyiSDK`).  Refer to the [SDK documentation](https://subor.github.io/api/cpp/en-US/) for API details.
1. Build your project.

## Building SDK Binary

You can also use a binary built from the [SDK source](https://github.com/subor/sdk).

1. [Build SDK Binary](build_sdk_source.md)

1. From `RuyiSDKCpp\bin\Release`, copy the __include__ and __lib__ folders to your main module (e.g. `Source/PlatformerGame/RuyiSDK/`).

1. Follow remainder of instructions from ["Using SDK Binary"](#using-sdk-binary)

## Visual Studio 2015

UE4 supports [several version of Visual Studio](https://docs.unrealengine.com/en-us/Programming/Development/VisualStudioSetup).  Starting with [4.20 VS 2017 is the default](https://trello.com/c/0ZLgilUM/280-use-visual-studio-2017-and-windows-10-sdk-by-default).

### Generating VS 2017 Projects

Starting with 4.15, you can generate your VS project files on command line with `-2017` param:

    UnrealBuildTool.exe -projectfiles -project="C:/XXX.uproject" -game -engine -progress -2017

If it stills use v140 toolset:

1. Open Registry Editor by running `regedit`
1. Locate `HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\VisualStudio\SxS\VC7`
1. Normally there is "14.0" and "15.0" keys.  Delete "14.0".  And, if it doesn't exist already, create "15.0" with value data of the install path of Visual Studio 2017 (e.g. `C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\VC`).  
![](/docs/img/unreal_compile_02.png)
1. Re-generate the project files on command line (using `-2017` again)
1. Open the sln project file, compile it, it should work fine.
1. You can add the "14.0" key back after you generate the project files

### v140

To target v140, you'll need to rebuild our SDK and all it's dependencies.

1. [Build SDK Binary](build_sdk_source.md), making sure all binaries target __v140__:
    - Boost can be built with `b2 toolset=msvc-14.0 address-model=64 --build-type=complete stage`
    - For libraries with Visual Studio projects, right-click a project and select __Properties__, for __Platform Toolset__ select `Visual Studio 2015 (v140)`:  
    ![](/docs/img/cpp_properties_toolset.png)

1. Follow remainder of instructions from ["Building SDK Binary"](#building-sdk-binary)

## Known Issues

- Since the SDK uses [boost](http://www.boost.org/), you may encounter `error LNK2038: mismatch detected for 'boost__type_index__abi': value 'RTTI is used'`.  You can solve this by adding `bUseRTTI = true;` to __xxxx.build.cs__.

- Similarly: `Error C4577: 'noexcept' used with no exception handling mode specified`.  You can solve this by adding `bEnableExceptions = true;` to __xxx.build.cs__.

- If you encounter:

        RuyiSDK.lib(RuyiNetService.obj) : error LNK2001: unresolved external symbol __std_reverse_trivially_swappable_1
        RuyiSDK.lib(RuyiNetVideoService.obj) : error LNK2001: unresolved external symbol __std_reverse_trivially_swappable_1
        RuyiSDK.lib(RuyiNetGamificationService.obj) : error LNK2001: unresolved external symbol __std_reverse_trivially_swappable_1
        D:\usr\sample_ue4_demo\Binaries\Win64\UE4Editor-RuyiSDKDemo.dll : fatal error LNK1120: 1 unresolved externals

This is caused by UE4 using __v140__ toolset while our C++ SDK binary is compiled with __v141__.  You need to do one of:

- [Generate VS 2017 UE4 projects](#generating-vs-2017-projects)
- [Build the SDK from source](#building-sdk-binary) targetting [VS 2015/v140](#v140)

# UE4 Integration

## Prerequisites

- [Visual Studio 2017](https://www.visualstudio.com/vs/community/) 15.3 version or later with following components:
    - Windows 10 SDK (10.0.15063.0)
- Tested with Unreal Engine 18, Compiled version

## Instructions

1. Our sdk file will be in two folders: __include__ and __lib__.  Put them in one of your game module source folder.  For example, `source/ModuleName/include` and `source/ModuleName/lib`.  They may be put in a sub-folder, just make sure they're in the same folder.
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
1. Open your project with Unreal Engine 4 Editor.  Click __File -> Refresh Visual Studio Project__ (or right-click __xxxxx.uproject__ file and click _Generate visual studio project file_).  Wait for it to finish, then reload your Visual Studio project and you will find "include" and "lib" folders in Solution Explorer.
1. When using SDK functions, include `RuyiSDK.h` and use apprpropriate namespaces (like `Ruyi::RuyiSDK`).  Refer to the [UE4 demo source code](https://bitbucket.org/playruyi/unreal_demo) and the [SDK documentation](http://dev.playruyi.com/api) for API details.
1. Build your project.

## Common Issues

- Since the sdk uses [boost](http://www.boost.org/), you may encounter `error LNK2038: mismatch detected for 'boost__type_index__abi': value 'RTTI is used'`.  You can solve this by adding `bUseRTTI = true;` to __xxxx.build.cs__.

- Similarly: `Error C4577: 'noexcept' used with no exception handling mode specified`.  You can solve this by adding `bEnableExceptions = true;` to __xxx.build.cs__.